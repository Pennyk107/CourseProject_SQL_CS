using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs_BD_v0._1
{

    [Table("ATS")]
    public class ATS
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id_ats { get; set; }
        public string? title { get; set; }
        public bool status { get; set; }
        public int year_of_opening { get; set; }
        public int id_area { get; set; }
        public string? license_to_provide_services { get; set; }
        

        public string? address { get; set; }

    }

    [Table("benefit")]
    public class benefit
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id_benefit_ats { get; set; }
        public int id_ats { get; set; }
        public int id_benefit { get; set; }
        public int id_type_of_payment { get; set; }
        public double coef { get; set; }
        public int id_social_status { get; set; }

    }

    [Table("call")]
    public class call
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id_call { get; set; }
        public DateTime call_date { get; set; }
        public int call_duration { get; set; }
        public int id_rate { get; set; }
        public int id_subscriber { get; set; }
        public int id_city { get; set; }
        public string? number_phone_friend { get; set; }
        public double cost { get; set; }
    }

    [Table ("rate")]
    public class rate{
        [System.ComponentModel.DataAnnotations.Key]
        public int id_rate { get; set; }
        public string? title_rate { get; set; }
        public TimeSpan start_call { get; set; }
        public TimeSpan end_call { get; set; }
        public double coefficient { get;set; }
    }

    [Table("subscriber")]
    public class subscriber
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id_subscriber { get; set; }
        public string? fullname { get; set; }

        public int id_ats { get; set; }
        public int? id_benefit { get; set; }
        public string? address_subscriber { get; set; }
        public int id_social_status { get; set; }
        public Byte[]? benefit_document { get; set; }
        public int id_area { get; set; }}
    }


