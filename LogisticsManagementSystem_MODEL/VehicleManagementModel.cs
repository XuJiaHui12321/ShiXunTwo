using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagementSystem_MODEL
{
    public class VehicleManagementModel
    {
        public int VehicleManagementId { get; set; }
        public string BrandAndModel { get; set; }
        public string LicensePlateNumber { get; set; }
        public string DriverName { get; set; }
        public string Company { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string OperationCertificateNo { get; set; }
        public DateTime ExpiryDateOfInsurance { get; set; }
        public DateTime ExpirationTimeOfAnnualInspection { get; set; }
        public string MaintenanceKilometers { get; set; }
        public string VehiclePhotos { get; set; }
        public string InsuranceCardPhoto { get; set; }
    }
}
