using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kornyakovpr9v7
{
    public struct PersonData
    {

        private string _name, _familya, _otchestvo, _address;
        private ulong _phoneNumber;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Familya
        {
            get { return _familya; }
            set { _familya = value; }
        }
        public string Otchestvo
        {
            get { return _otchestvo; }
            set { _otchestvo = value; }
        }
        public ulong PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public PersonData()
        {
            _name = "Введите имя";
            _familya = "Введите фамилию";
            _otchestvo = "Введите отчество";
            _address = "Введите адрес";
            _phoneNumber = 0;
        }

        public static List<string> GetResult(List<PersonData> list, string address)
        {
            List<string> result = new List<string>();

            foreach (PersonData i in list)
            {
                if (i.Address == address) result.Add(i.Name);
            }
            if (result.Count == 0)
            {
                throw new ArgumentException("Таких  нет у нас на районе");
            }
            return result;
        }

    }
}
