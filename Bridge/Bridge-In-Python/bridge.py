"""
The Bridge Design Pattern is a structural pattern that decouples an abstraction from its implementation so that the two can vary independently.
It is particularly useful when you have a class that could be extended in multiple ways but you want to avoid a combinatorial explosion of subclasses.
"""

from abc import ABC, abstractmethod

# The Implementor
class IDevice(ABC):  # Normal abstraction with TV and Radio
    @abstractmethod
    def turn_on(self):
        pass

    @abstractmethod
    def turn_off(self):
        pass

    @abstractmethod
    def set_volume(self, percent: int):
        pass


# Concrete Implementor A
class TV(IDevice):
    # Change the implementation based on your need
    def turn_on(self):
        print("TV is now ON")

    def turn_off(self):
        print("TV is now OFF")

    def set_volume(self, percent: int):
        print(f"TV volume set to {percent}%")


# Concrete Implementor B
class Radio(IDevice):
    # Change the implementation based on your need
    def turn_on(self):
        print("Radio is now ON")

    def turn_off(self):
        print("Radio is now OFF")

    def set_volume(self, percent: int):
        print(f"Radio volume set to {percent}%")


# The Abstraction
class RemoteControl:
    def __init__(self, device: IDevice):
        self.device = device

    def turn_on(self):
        self.device.turn_on()

    def turn_off(self):
        self.device.turn_off()


# Refined Abstraction
class AdvancedRemoteControl(RemoteControl):  # Re-structure the abstraction (RemoteControl)
    """
    Here you can modify the abstraction in a new way while taking the old implementation:
    1. Use old implementation.
    2. Override (refine) current implementation.
    3. Add new implementation.
    """

    def __init__(self, device: IDevice):
        super().__init__(device)

    # Refined implementation of set_volume
    def set_volume(self, percent: int):
        if percent < 0 or percent > 100:
            print("Volume out of range. Setting to default 50%.")
            percent = 50
        print(f"Setting volume to {percent}% via AdvancedRemoteControl.")
        self.device.set_volume(percent)

    # Add new implementation
    def mute(self):
        print("Muting the device.")
        self.device.set_volume(0)


# Client Code
def main():
    # Using TV with an advanced remote
    tv = TV()
    advanced_remote_for_tv = AdvancedRemoteControl(tv)
    advanced_remote_for_tv.turn_on()
    advanced_remote_for_tv.set_volume(150)  # Test out-of-range volume
    advanced_remote_for_tv.mute()
    advanced_remote_for_tv.turn_off()

    print()

    # Using Radio with an advanced remote
    radio = Radio()
    advanced_remote_for_radio = AdvancedRemoteControl(radio)
    advanced_remote_for_radio.turn_on()
    advanced_remote_for_radio.set_volume(30)  # Test valid volume
    advanced_remote_for_radio.mute()
    advanced_remote_for_radio.turn_off()


if __name__ == "__main__":
    main()
