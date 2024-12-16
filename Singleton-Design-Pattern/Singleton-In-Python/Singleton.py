class Singleton:
    x = ""
    y = ""

    _instance = None

    @staticmethod
    def get_singleton_instance():
        if Singleton._instance is None:
            Singleton._instance = Singleton()

        return Singleton._instance

obj1 = Singleton.get_singleton_instance()
obj2 = Singleton.get_singleton_instance()


print(obj1 is obj2)  # True