using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Contracts;
using Entities.Models;
using MagicPOS.CloudinaryStore;
using MagicPOS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared.DTO.Device;
using System.Globalization;

namespace InventrySystem.Controllers
{
    [Route("api/devices")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IImageUploadService _imageUploadService;

        private readonly Cloudinary _cloudinary;
        private IOptions<CloudinarySettings> _cloudinarySettings;

        public DeviceController(ILoggerManager logger, IRepositoryManager repository, 
            IMapper mapper,IOptions<CloudinarySettings> cloudinarySettings, IImageUploadService imageUploadService)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _cloudinarySettings = cloudinarySettings;
            _imageUploadService = imageUploadService;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllDevices()
        {
            try
            {
                var devices = await _repository.Device.GetAllDevicesAsync(trackChanges: false);
                _logger.LogInfo("Returned all devices from database.");

                var devicesResult = _mapper.Map<IEnumerable<DeviceDto>>(devices);
                return Ok(devicesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllDevices action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAllAvailableDevices()
        {
            try
            {
                var devices = await _repository.Device.GetAllAvailableDevicesAsync(trackChanges: false);
                _logger.LogInfo("Returned all devices from database.");

                var devicesResult = _mapper.Map<IEnumerable<DeviceDto>>(devices);
                return Ok(devicesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllDevices action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllFaultDevices()
        {
            try
            {
                var devices = await _repository.Device.GetAllFaultDevicesAsync(trackChanges: false);
                _logger.LogInfo("Returned all devices from database.");

                var devicesResult = _mapper.Map<IEnumerable<DeviceDto>>(devices);
                return Ok(devicesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllDevices action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("count")]
        public async Task<IActionResult> GetDeviceCountPerCategory()
        {
            try
            {
                var categoryDeviceCounts = await _repository.Device.GetDeviceCountPerCategoryAsync(trackChanges: false);
                _logger.LogInfo("Returned device counts per category from database.");

                return Ok(categoryDeviceCounts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDeviceCountPerCategory action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{id}", Name = "DeviceById")]
        public async Task<IActionResult> GetDeviceById(Guid id)
        {
            try
            {
                var device = await _repository.Device.GetDeviceByIdAsync(id, trackChanges: false);
                if (device == null)
                {
                    _logger.LogError($"Device with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _logger.LogInfo($"Returned device with id: {id}");

                var deviceResult = _mapper.Map<DeviceDto>(device);
                return Ok(deviceResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDeviceById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevice([FromForm] DeviceForCreationDto device)
        {
            try
            {
                if (device == null)
                {
                    _logger.LogError("Device object sent from client is null.");
                    return BadRequest("Device object is null");
                }
                //image
                if (device.ImagePath == null || device.ImagePath.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid device object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var cloudinaryUrl = "cloudinary://863748169153569:rCWQU-T3dJDIOWP2KMMOAPsFSvg@dtm5fjebv";

                Cloudinary cloudinary = new Cloudinary(cloudinaryUrl);

                var uploadResult = new ImageUploadResult();

                using (var stream = device.ImagePath.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(device.ImagePath.FileName, stream),
                        UseFilename = true,
                        UniqueFilename = true,
                        Overwrite = true
                       /* Transformation = new Transformation().Width(500).Height(500).Crop("fill")*/
                    };

                    /*uploadResult =await _cloudinary.UploadAsync(uploadParams);*/
                    uploadResult =await cloudinary.UploadAsync(uploadParams);
                }

                if (uploadResult.Error != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, uploadResult.Error.Message);
                }

                var deviceEntity = _mapper.Map<Device>(device);

                deviceEntity.imageUrl=uploadResult.SecureUrl.AbsoluteUri;

                _repository.Device.CreateDevice(deviceEntity);
                _repository.SaveAsync();

                var createdDevice = _mapper.Map<DeviceDto>(deviceEntity);

                return CreatedAtRoute("DeviceById", new { id = createdDevice.Id }, createdDevice);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateDevice action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }



        /*[HttpPost("bulk")]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File not provided");

            var products = new List<Device>();

            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                while (!stream.EndOfStream)
                {
                    var line = await stream.ReadLineAsync();
                    var values = line.Split(',');

                    var categoryName = values[2]; 
                    var brandName = values[3];    
                    var supplierName = values[4];

                    var category = _repository.Category.GetByNameAsync(categoryName, trackChanges: false);
                    var brand = _repository.Brand.GetByNameAsync(brandName, trackChanges: false);
                    var supplier = _repository.Brand.GetByNameAsync(supplierName,trackChanges: false);

                    if (category == null || brand == null || supplier == null)
                        return BadRequest("Invalid category, brand, or supplier in CSV");


                    var product = new Device
                    {
                        Id=new Guid(),
                        Name = values[0],
                        SerialNumber = values[1],
                        CategoryId = Guid.Parse(category.Id),
                        BrandId = values[3],
                        SupplierId = values[4],
                        Price = decimal.Parse(values[5], CultureInfo.InvariantCulture),
                        Quantity = int.Parse(values[6]),
                        imageUrl=values[7],
                        Status =values[8],
                    };

                    products.Add(product);
                }
            }

            _repository.Device.AddRange(products);
           _repository.SaveAsync();

            return Ok(new { Count = products.Count, Message = "Products imported successfully" });
    }
    */


    [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(Guid id, [FromBody] DeviceForUpdateDto device)
        {
            try
            {
                if (device == null)
                {
                    _logger.LogError("Device object sent from client is null.");
                    return BadRequest("Device object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid device object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var deviceEntity = await _repository.Device.GetDeviceByIdAsync(id, trackChanges: true);
                if (deviceEntity == null)
                {
                    _logger.LogError($"Device with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(device, deviceEntity);

                _repository.Device.UpdateDevice(deviceEntity);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateDevice action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(Guid id)
        {
            try
            {
                var device = await _repository.Device.GetDeviceByIdAsync(id, trackChanges: false);
                if (device == null)
                {
                    _logger.LogError($"Device with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Device.DeleteDevice(device);
                _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteDevice action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
