from abc import ABC, abstractmethod

class IFormState(ABC):
    @abstractmethod
    def next(self, context):
        pass

    @abstractmethod
    def previous(self, context):
        pass

    @abstractmethod
    def display(self, context):
        pass


class PageOneState(IFormState):
    def __init__(self):
        self.full_name = ""
        self.age = 0

    def next(self, context):
        context.set_state(context.page_two)

    def previous(self, context):
        print("Already on the first page.")

    def display(self, context):
        print("Page 1: Personal Info")
        self.full_name = input("Full Name: ")
        try:
            self.age = int(input("Age: "))
        except ValueError:
            self.age = 0
        print(f"Saved: {self.full_name}, Age: {self.age}")


class PageTwoState(IFormState):
    def __init__(self):
        self.email = ""
        self.phone = ""

    def next(self, context):
        context.set_state(context.page_three)

    def previous(self, context):
        context.set_state(context.page_one)

    def display(self, context):
        print("Page 2: Contact Info")
        self.email = input("Email: ")
        self.phone = input("Phone: ")
        print(f"Saved: {self.email}, {self.phone}")


class PageThreeState(IFormState):
    def __init__(self):
        self.country = ""
        self.city = ""

    def next(self, context):
        context.set_state(context.page_four)

    def previous(self, context):
        context.set_state(context.page_two)

    def display(self, context):
        print("Page 3: Address Info")
        self.country = input("Country: ")
        self.city = input("City: ")
        print(f"Saved: {self.country}, {self.city}")


class PageFourState(IFormState):
    def next(self, context):
        print("Submitting form...")

    def previous(self, context):
        context.set_state(context.page_three)

    def display(self, context):
        print("Page 4: Summary / Submit")
        p1 = context.page_one
        p2 = context.page_two
        p3 = context.page_three

        print(f"Name: {p1.full_name}, Age: {p1.age}")
        print(f"Email: {p2.email}, Phone: {p2.phone}")
        print(f"Country: {p3.country}, City: {p3.city}")
        input("Press Enter to submit...")
        print("Form Submitted!")


class FormContext:
    def __init__(self):
        self.page_one = PageOneState()
        self.page_two = PageTwoState()
        self.page_three = PageThreeState()
        self.page_four = PageFourState()
        self.current_state = self.page_one

    def set_state(self, state):
        self.current_state = state

    def next(self):
        self.current_state.next(self)

    def previous(self):
        self.current_state.previous(self)

    def display(self):
        self.current_state.display(self)


def main():
    form = FormContext()

    while True:
        form.display()
        command = input("\nEnter action (next / prev / exit): ").lower()

        if command == "next":
            form.next()
        elif command == "prev":
            form.previous()
        elif command == "exit":
            break

        print("\n-----------------------------\n")

    print("Form closed.")


if __name__ == "__main__":
    main()
