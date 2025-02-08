# The Chain of Responsibility pattern is a behavioral design pattern that allows multiple handlers to process a request sequentially. 
# Each handler in the chain either processes the request or passes it to the next handler.

class SupportHandler:
    def __init__(self):
        self._next_handler = None

    def set_next_handler(self, next_handler):
        self._next_handler = next_handler

    def handle_request(self, issue):
        if self._next_handler:
            self._next_handler.handle_request(issue)
        else:
            print(f"No handler available for: {issue}")


class BasicSupport(SupportHandler):
    def handle_request(self, issue):
        if issue == "password reset":
            print("Basic Support: Handling password reset.")
        elif self._next_handler:
            self._next_handler.handle_request(issue)
        else:
            print("Basic Support: Issue cannot be handled.")


class TechnicalSupport(SupportHandler):
    def handle_request(self, issue):
        if issue == "server down":
            print("Technical Support: Handling server down issue.")
        elif self._next_handler:
            self._next_handler.handle_request(issue)
        else:
            print("Technical Support: Issue cannot be handled.")


class ManagerSupport(SupportHandler):
    def handle_request(self, issue):
        print(f"Manager Support: Handling complex issue - {issue}")


# Setting up the chain
basic_support = BasicSupport()
tech_support = TechnicalSupport()
manager_support = ManagerSupport()

basic_support.set_next_handler(tech_support)
tech_support.set_next_handler(manager_support)

# Sending requests
print("Client: Requesting password reset...")
basic_support.handle_request("password reset")

print("\nClient: Reporting server down...")
basic_support.handle_request("server down")

print("\nClient: Requesting a refund...")
basic_support.handle_request("refund")









