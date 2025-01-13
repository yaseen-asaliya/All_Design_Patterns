class IButton:
    """Abstract Product A"""
    def render(self):
        raise NotImplementedError("Render method must be implemented.")


class LightButton(IButton):
    """Concrete Product A1"""
    def render(self):
        print("Rendering Light Button")


class DarkButton(IButton):
    """Concrete Product A2"""
    def render(self):
        print("Rendering Dark Button")


class ICheckbox:
    """Abstract Product B"""
    def render(self):
        raise NotImplementedError("Render method must be implemented.")


class LightCheckbox(ICheckbox):
    """Concrete Product B1"""
    def render(self):
        print("Rendering Light Checkbox")


class DarkCheckbox(ICheckbox):
    """Concrete Product B2"""
    def render(self):
        print("Rendering Dark Checkbox")


class IThemeFactory:
    """Abstract Factory"""
    def create_button(self):
        raise NotImplementedError("CreateButton method must be implemented.")

    def create_checkbox(self):
        raise NotImplementedError("CreateCheckbox method must be implemented.")


class LightThemeFactory(IThemeFactory):
    """Concrete Factory 1"""
    def create_button(self):
        return LightButton()

    def create_checkbox(self):
        return LightCheckbox()


class DarkThemeFactory(IThemeFactory):
    """Concrete Factory 2"""
    def create_button(self):
        return DarkButton()

    def create_checkbox(self):
        return DarkCheckbox()


def main():
    # Create Light Theme Factory
    light_theme_factory = LightThemeFactory()
    print("Using Light Theme:")
    light_button = light_theme_factory.create_button()
    light_checkbox = light_theme_factory.create_checkbox()
    light_button.render()
    light_checkbox.render()

    # Create Dark Theme Factory
    dark_theme_factory = DarkThemeFactory()
    print("\nUsing Dark Theme:")
    dark_button = dark_theme_factory.create_button()
    dark_checkbox = dark_theme_factory.create_checkbox()
    dark_button.render()
    dark_checkbox.render()


if __name__ == "__main__":
    main()
