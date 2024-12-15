using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasData(
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Lenovo ThinkPad",
                    SerialNumber = "SN123456",
                    CategoryId = new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"),
                    BrandId = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                    SupplierId = new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"),
                    Status = true,
                    Price=250000,
                    Quantity=20,
                    imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854815/images/c4w6df0r9nm4l3ftryto.jpg"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Dell Inspiron",
                    SerialNumber = "SN789012",
                    CategoryId = new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"),
                    BrandId = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                    SupplierId = new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"),
                    Status = true,
                    Price = 140000,
                    Quantity = 10,
                    imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734058042/scy7zp5v72vlhudufnzy.jpg"

                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Lenovo LOQ",
                    SerialNumber = "SN345678",
                    CategoryId = new Guid("9aa0f4cd-de28-4d3c-b38b-586819845ba3"),
                    BrandId = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                    SupplierId = new Guid("029e2d94-fd9d-41bd-9b4a-58b2f738c662"),
                    Status = false,
                    Price = 280000,
                    Quantity = 5,
                    imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854812/images/rol33mjrwr9380xp4xnv.jpg"

                },

               
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "I7 10th Gen",
                    SerialNumber = "SN246810",
                    CategoryId = new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"),
                    BrandId = new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"),
                    SupplierId = new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"),
                    Status = false,
                    Price = 120000,
                    Quantity = 2,
                    imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854818/images/y2ajycr8e3xbb1585gxg.png"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "I3 13th Gen",
                    SerialNumber = "SN567890",
                    CategoryId = new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"),
                    BrandId = new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"),
                    SupplierId = new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"),
                    Status = false,
                    Price = 110000,
                    Quantity = 3,
                    imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734063664/images/nv8ozozlc95wbokb7xts.jpg"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "I5 12th Gen",
                    SerialNumber = "SN112233",
                    CategoryId = new Guid("afc1bef3-e71d-4bd8-9bb2-c838c40e9ee0"),
                    BrandId = new Guid("89491906-e1e3-4d90-b8da-7363d1d92518"),
                    SupplierId = new Guid("ec98376a-b287-458c-96b8-18aef57eb9f0"),
                    Status = false,
                    Price = 140000,
                    Quantity = 4,
                    imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734063778/images/fif9q0fxmfdii59arhlv.jpg"
                },

                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Canon Inkjet",
                    SerialNumber = "SN987654",
                    CategoryId = new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"),
                    BrandId = new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"),
                    SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                    Status = false,
                    Price = 50000,
                    Quantity = 6,
                    imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854811/images/qmibmebvowduiziqsurw.jpg"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "HP Smart Tank ",
                    SerialNumber = "SN456789",
                    CategoryId = new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"),
                    BrandId = new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"),
                    SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                    Status = false,
                    Price = 60000,
                    Quantity = 8,
                    imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854813/images/wp7jvyj4r2fa5zxbpsvy.jpg"
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "HP DeskJet ink",
                    SerialNumber = "SN135790",
                    CategoryId = new Guid("42a2b158-1964-47da-8c4e-31a249aa1b3a"),
                    BrandId = new Guid("ffb0451c-5f0b-457d-a513-e308e9b87326"),
                    SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                    Status = false,
                    Price = 45000,
                    Quantity = 2,
                    imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734063998/images/kko6rsjsh8t2tzhpnjbf.jpg"
                },
                 new Device
                 {
                     Id = Guid.NewGuid(),
                     Name = "Iphone 15 pro",
                     SerialNumber = "SN789012",
                     CategoryId = new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"),
                     BrandId = new Guid("302a431a-2f54-4768-8a34-b6414f3909df"),
                     SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                     Status = true,
                     Price = 250000,
                     Quantity = 3,
                     imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854972/images/rwpvbxtu1xuclw94vi6f.png"
                 },
            new Device
            {
                Id = Guid.NewGuid(),
                Name = "Iphone 11",
                SerialNumber = "SN456789",
                CategoryId = new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"),
                BrandId = new Guid("302a431a-2f54-4768-8a34-b6414f3909df"),
                SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                Status = true,
                Price = 150000,
                Quantity = 5,
                imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1734063996/images/vgsjribmbko82wpih351.jpg"
            },
            new Device
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Galaxy A06",
                SerialNumber = "SN135790",
                CategoryId = new Guid("f8f32941-7bad-471e-9d15-07b0ed660516"),
                BrandId = new Guid("f10323d3-da72-44e7-ae7d-0379da31b329"),
                SupplierId = new Guid("3fff2d50-83f4-4128-a5dd-bb74f0d754e8"),
                Status = true,
                Price = 64000,
                Quantity = 4,
                imageUrl = "https://res.cloudinary.com/dtm5fjebv/image/upload/v1733854971/images/yiyrnaiw7zoubg4q1l9c.png"

            }
            );
        }
    }

}
