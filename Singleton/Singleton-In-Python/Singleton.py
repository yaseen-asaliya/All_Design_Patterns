class Singleton:
    # You can add attributes here...

    # Private class-level attribute to hold the single instance
    _instance = None  

    # Static method to provide access to the single instance of the class.
    @staticmethod
    def get_singleton_instance(): 
        if Singleton._instance is None:  # Check if an instance already exists
            Singleton._instance = Singleton()  # Create the instance (first and only one time)
        return Singleton._instance 

obj1 = Singleton.get_singleton_instance()
obj2 = Singleton.get_singleton_instance()

# Verify that both objects refer to the same instance
print(obj1 is obj2)  # True
