﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBPS.Application.DTOs.BuildingApplication
{
    public class HouseOwnerDTO
    {
        public int Id { get; set; }
        public int? ApplicationId { get; set; }
        public int Salutation { get; set; }
        public int HouseOwnerType { get; set; }
        public string HouseOwnerName { get; set; }
        public string? HouseOwnerPhotoPath { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Tole { get; set; }
        public string CitizenshipNumber { get; set; }
        public string CitizenshipIssueDate { get; set; }
        public int CitizenshipIssueDistrict { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int WardNumber { get; set; }
        public string Address { get; set; }
    }
}
