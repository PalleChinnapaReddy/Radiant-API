using System;
using System.Collections.Generic;

namespace Radiant.DataAccess.Models
{
    public partial class Payroll
    {
        public long Payrollid { get; set; }
        public long? Empid { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public long? Currencyid { get; set; }
        public double? Currentbasic { get; set; }
        public double? Currenthra { get; set; }
        public double? Currentgross { get; set; }
        public double? Currentpayperhour { get; set; }
        public double? Currentpayperday { get; set; }
        public double? Arrearsbasic { get; set; }
        public double? Arrearshra { get; set; }
        public double? Arrearsgross { get; set; }
        public double? Arrearspayperhour { get; set; }
        public double? Arrearspayperday { get; set; }
        public double? Currentworkeddays { get; set; }
        public double? Arrearsworkeddays { get; set; }
        public double? Workeddays { get; set; }
        public double? Totalworkingdays { get; set; }
        public double? Currentothours { get; set; }
        public double? Arrearsothours { get; set; }
        public double? Othours { get; set; }
        public double? Currentnonothours { get; set; }
        public double? Arrearsnonothours { get; set; }
        public double? Nonothours { get; set; }
        public double? Attendanceincentive { get; set; }
        public double? Currentotpay { get; set; }
        public double? Arrearsotpay { get; set; }
        public double? Leavewithwage { get; set; }
        public double? Currentnightshiftallowances { get; set; }
        public double? Arrearsnightshiftallowances { get; set; }
        public double? Currentearnedbasic { get; set; }
        public double? Arrearsearnedbasic { get; set; }
        public double? Currentearnedhra { get; set; }
        public double? Arrearsearnedhra { get; set; }
        public double? Currentearnedgross { get; set; }
        public double? Arrearsearnedgross { get; set; }
        public double? Ratingallowances { get; set; }
        public double? Otherallowances { get; set; }
        public double? Pfemployee { get; set; }
        public double? Esicemployee { get; set; }
        public double? Pfemployer { get; set; }
        public double? Esicemployer { get; set; }
        public double? Servicecharge { get; set; }
        public double? Pt { get; set; }
        public double? Canteen { get; set; }
        public double? Transport { get; set; }
        public double? Refundabledeposit { get; set; }
        public double? Otherdeduction { get; set; }
        public double? Grosswages { get; set; }
        public double? Totaldeduction { get; set; }
        public double? Netamount { get; set; }
        public double? Asubtotalgrosswage { get; set; }
        public double? Bsubtotalstatuory { get; set; }
        public double? Csubtotal { get; set; }
        public double? Ctc { get; set; }
        public bool? Isactive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public double? Arrearsweekoffpresent { get; set; }
        public double? Currentweekoffpresent { get; set; }
        public double? Arrearsholidaypresent { get; set; }
        public double? Currentholidaypresent { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Employee Emp { get; set; }
    }
}
