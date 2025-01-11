from enum import Enum

class PhoneType(Enum):
    iPhone = 1
    Samsung = 2
    Other = 3


# 1. Target Interface
class ICharger:
    def charge_phone(self, phone_type: PhoneType):
        pass


# 2. Adaptee (Incompatible Classes)
class LightningCharger:
    def charge_with_lightning(self):
        print("Charging iPhone using Lightning port.")


class USBCharger:
    def charge_with_usb(self):
        print("Charging Samsung phone using USB-C port.")


# 3. Adapter Class
class ChargerAdapter(ICharger):
    def __init__(self, phone_type: PhoneType):
        if phone_type == PhoneType.iPhone:
            self._charger = LightningCharger()
        elif phone_type == PhoneType.Samsung:
            self._charger = USBCharger()
        else:
            raise ValueError("Unsupported phone type.")

    def charge_phone(self, phone_type: PhoneType):
        if phone_type == PhoneType.iPhone:
            self._charger.charge_with_lightning()
        elif phone_type == PhoneType.Samsung:
            self._charger.charge_with_usb()
        else:
            raise ValueError("Unsupported phone type.")


if __name__ == "__main__":
    try:
        iphone_charger = ChargerAdapter(PhoneType.iPhone)
        samsung_charger = ChargerAdapter(PhoneType.Samsung)

        iphone_charger.charge_phone(PhoneType.iPhone) 
        samsung_charger.charge_phone(PhoneType.Samsung) 

        unsupported_charger = ChargerAdapter(PhoneType.Other)
        unsupported_charger.charge_phone(PhoneType.Other) 
    except ValueError as e:
        print(e) 
