import { ApplicantDetailsModel } from "./applicant-details.model";
import { ApplicationDetailsModel } from "./application-details.model";
import { CharkillaModel } from "./charkilla.model";
import { HouseOwnerModel } from "./house-owner.model";
import { LandInformationModel } from "./land-information.model";
import { LandOwnerModel } from "./land-owner.model";

export interface BuildingApplicationData {
    applicationDetails: ApplicationDetailsModel;
    applicantDetails: ApplicantDetailsModel;
    landInformationList: LandInformationModel[];
    houseOwnerList: HouseOwnerModel[];
    landOwnerList: LandOwnerModel[];
    charkillaList: CharkillaModel[];
  }
  