from abc import ABC, abstractmethod

# The Command interface declares a method for executing a command.
class ICommand(ABC):
    @abstractmethod
    def execute(self):
        pass

# Some commands can implement simple operations on their own.
class SimpleCommand(ICommand):
    def __init__(self, payload: str):
        self._payload = payload

    def execute(self):
        print(f"SimpleCommand: See, I can do simple things like printing ({self._payload})")

# However, some commands can delegate more complex operations to other
# objects, called "receivers."
class ComplexCommand(ICommand):
    def __init__(self, receiver, a: str, b: str):
        # Context data, required for launching the receiver's methods.
        self._receiver = receiver
        self._a = a
        self._b = b

    # Commands can delegate to any methods of a receiver.
    def execute(self):
        print("ComplexCommand: Complex stuff should be done by a receiver object.")
        self._receiver.do_something(self._a)
        self._receiver.do_something_else(self._b)

# The Receiver classes contain some important business logic. They know how
# to perform all kinds of operations, associated with carrying out a
# request. In fact, any class may serve as a Receiver.
class Receiver:
    def do_something(self, a: str):
        print(f"Receiver: Working on ({a}.)")

    def do_something_else(self, b: str):
        print(f"Receiver: Also working on ({b}.)")

# The Invoker is associated with one or several commands. It sends a
# request to the command.
class Invoker:
    def __init__(self):
        self._on_start = None
        self._on_finish = None

    # Initialize commands.
    def set_on_start(self, command: ICommand):
        self._on_start = command

    def set_on_finish(self, command: ICommand):
        self._on_finish = command

    # The Invoker does not depend on concrete command or receiver classes.
    # The Invoker passes a request to a receiver indirectly, by executing a
    # command.
    def do_something_important(self):
        print("Invoker: Does anybody want something done before I begin?")
        if isinstance(self._on_start, ICommand):
            self._on_start.execute()
        
        print("Invoker: ...doing something really important...")
        
        print("Invoker: Does anybody want something done after I finish?")
        if isinstance(self._on_finish, ICommand):
            self._on_finish.execute()

# The client code can parameterize an invoker with any commands.
if __name__ == "__main__":
    invoker = Invoker()
    invoker.set_on_start(SimpleCommand("Say Hi!"))
    receiver = Receiver()
    invoker.set_on_finish(ComplexCommand(receiver, "Send email", "Save report"))
    invoker.do_something_important()

    