# Subsystem Classes
class Projector:
    # Add class specifications here 
    def on(self):
        # Specific implemetation here
        print("Projector is On.")
    
    def off(self):
        # Specific implemetation here
        print("Projector is Off.")


class Amplifier:
    # Add class specifications here 
    def on(self):
        # Specific implemetation here
        print("Amplifier is On.")
    
    def set_volume(self, level):
        # Specific implemetation here
        print(f"Amplifier volume set to {level}.")


class DVDPlayer:
    # Add class specifications here 
    def on(self):
        # Specific implemetation here
        print("DVD Player is On.")
    
    def play(self, movie):
        # Specific implemetation here
        print(f"Playing movie: {movie}")


class Lights:
    # Add class specifications here 
    def dim(self, level):
        # Specific implemetation here
        print(f"Lights dimmed to {level}%.")


# Facade Class
class HomeTheaterFacade:
    # Add class specifications here 
    def __init__(self, projector, amplifier, dvd_player, lights):
        self.projector = projector
        self.amplifier = amplifier
        self.dvd_player = dvd_player
        self.lights = lights

    def watch_movie(self, movie):
        # Specific implemetation here
        print("\nGet ready to watch a movie...")
        self.lights.dim(20)
        self.projector.on()
        self.amplifier.on()
        self.amplifier.set_volume(10)
        self.dvd_player.on()
        self.dvd_player.play(movie)

    def end_movie(self):
        # Specific implemetation here
        print("\nShutting down movie theater...")
        self.dvd_player.on()
        self.amplifier.on()
        self.projector.off()
        self.lights.dim(100)


if __name__ == "__main__":
    # Create subsystem components
    projector = Projector()
    amplifier = Amplifier()
    dvd_player = DVDPlayer()
    lights = Lights()

    # Create the facade
    home_theater = HomeTheaterFacade(projector, amplifier, dvd_player, lights)

    # Use the facade
    home_theater.watch_movie("Inception")
    home_theater.end_movie()
