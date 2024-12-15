export interface Device {
    id: string;
    name: string;
    serialNumber: string;
    categoryId?: string;
    categoryName: string;
    brandId:string;
    brandName: string;
    supplierId:string;
    supplierName: string;
    isFaulty: boolean;
    price:number;
    quantity:number;
    imageUrl:string;
  }

  export interface DeviceCategoryReport {
    categoryName: string;
    totalDevices: number;
    available: number;
    faulty: number;
  }
