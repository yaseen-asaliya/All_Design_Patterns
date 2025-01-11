from Factory.producer_class import Producer

# create animals
Producer.add_animal("Cat")
Producer.add_animal("Dog")
Producer.add_animal("Dog")
Producer.add_animal("Cat")
Producer.add_animal("Cat")

# print animals
for animal in Producer.animals:
    animal.make_noise()
