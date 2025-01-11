import { HouseOwnerData } from "./house-owner.model";

export interface BuildingApplicationData {
    transactionType: string;
    buildingPurpose: string;
    nbcClass: string;
    landUseZone: string;
    landUseSubZone: string;
    structureType: string;
  
    salutation: string;
    applicantName: string;
    wardNumber: string;
    address: string;
    houseNumber: string;
    phoneNumber: string;
    email: string;

    HouseOwnerList: HouseOwnerData[]; // List of house owner data
  }
  