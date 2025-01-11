using System;

namespace AdapterPatternExample
{
    // Enum to represent different phone types
    public enum PhoneType
    {
        iPhone,
        Samsung,
        Other
    }

    // 1. Target Interface
    public interface ICharger
    {
        void ChargePhone(PhoneType phoneType);
    }

    // 2. Adaptee (Incompatible Classes)
    public class LightningCharger
    {
        public void ChargeWithLightning()
        {
            Console.WriteLine("Charging iPhone using Lightning port.");
        }
    }

    public class USBCharger
    {
        public void ChargeWithUSB()
        {
            Console.WriteLine("Charging Samsung phone using USB-C port.");
        }
    }

    // 3. Adapter Class
    public class ChargerAdapter : ICharger
    {
        private readonly object _charger;

        public ChargerAdapter(PhoneType phoneType)
        {
            switch (phoneType)
            {
                case PhoneType.iPhone:
                    _charger = new LightningCharger();
                    break;
                case PhoneType.Samsung:
                    _charger = new USBCharger();
                    break;
                default:
                    throw new ArgumentException("Unsupported phone type.");
            }
        }

        public void ChargePhone(PhoneType phoneType)
        {
            switch (phoneType)
            {
                case PhoneType.iPhone:
                    ((LightningCharger)_charger).ChargeWithLightning();
                    break;
                case PhoneType.Samsung:
                    ((USBCharger)_charger).ChargeWithUSB();
                    break;
                default:
                    throw new ArgumentException("Unsupported phone type.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ICharger iphoneCharger = new ChargerAdapter(PhoneType.iPhone);
                ICharger samsungCharger = new ChargerAdapter(PhoneType.Samsung);

                iphoneCharger.ChargePhone(PhoneType.iPhone);  
                samsungCharger.ChargePhone(PhoneType.Samsung); 

                // Example of unsupported phone type
                ICharger unsupportedCharger = new ChargerAdapter(PhoneType.Other);
                unsupportedCharger.ChargePhone(PhoneType.Other); 
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message); 
            }
        }
    }
}
