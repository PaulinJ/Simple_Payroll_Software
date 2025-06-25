using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Payroll_Software
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

        }
    }


    class Staff
    {
        private float hourlyRate;
        private int hWorked;
        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }

        public int HoursWorked
        {
            get { return hWorked; }
            set 
            {
                if(value > 0)
                {
                    hWorked = value;
                }
                else
                {
                    hWorked = 0;
                }
                
            } 
        }
        public Staff(string name, float rate)
        {
            this.NameOfStaff = name;
            this.hourlyRate = rate;
        }


        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay ...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }
        public override string ToString()
        {
            return $"Name: {NameOfStaff} Hours Worked: {HoursWorked} Pay: {TotalPay}";
        }
    }


    class Manager : Staff
    {
        private const float managerHourlyRate = 50;
        public int Allowance { get; private set; }

        public Manager(string name) : base (name, managerHourlyRate)
        {
            
        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if(HoursWorked > 160)
            {
                Allowance = 1000;
                TotalPay += Allowance;

            }

        }

        public override string ToString()
        {
            return $"Name: {NameOfStaff} Hours Worked: {HoursWorked} Pay: {TotalPay}";
        } 
        
    }

    class Admin : Staff
    {
        private const float overtimeRate = 15.5F;
        private const float adminHourlyRate = 30;

        public float Overtime { get; private set; }

        public Admin(string name) : base(name, adminHourlyRate)
        {
            
        }

        public override void CalculatePay()
        {
            base .CalculatePay();
            if (HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160);
                TotalPay += Overtime;
            }
        }
        public override string ToString()
        {
            return $"Name: {NameOfStaff} Hours Worked: {HoursWorked} Pay: {TotalPay}";
        }

    }

    class FileReader
    {
        public List<Staff> ReadFile()
        {
            string fileName = "staff.txt";
           
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string[] separator = {", "};
            

            if (File.Exists(fileName))
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
                StreamReader inFile = new StreamReader(fileStream);

                
            }

        }

    }

    class PaySlip
    {

        

    }
}
