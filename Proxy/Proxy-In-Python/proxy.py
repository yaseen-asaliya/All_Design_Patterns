from abc import ABC, abstractmethod

class ISubject(ABC):
    @abstractmethod
    def request(self):
        pass

# Expensive Object
class RealSubject(ISubject):
    def __init__(self):
        print("RealSubject: Initialized.")

    def request(self):
        print("RealSubject: Handling request.")

# Lazy Loading & Access Control
class Proxy(ISubject):
    def __init__(self, has_access: bool):
        self._real_subject = None
        self._has_access = has_access

    def request(self):
        if not self._has_access:
            print("Proxy: Access denied.")
            return

        if self._real_subject is None:
            self._real_subject = RealSubject()  # Lazy initialization

        print("Proxy: Forwarding request to RealSubject.")
        self._real_subject.request()

if __name__ == "__main__":
    print("Client: Using Proxy with access.")
    proxy_with_access = Proxy(True)
    proxy_with_access.request()

    print("\nClient: Using Proxy without access.")
    proxy_without_access = Proxy(False)
    proxy_without_access.request()
