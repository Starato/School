from random import randrange

class Animals:

    def __init__(self, name, animalType, mood):
        self.__animalType = animalType
        self.__name = name
        self.mood = mood

    def get_animalType(self):
        return self.__animalType

    def get_name(self):
        return self.__name
    
    def checkMood(self):
        self.__mood = randrange(1,4)
        if(self.__mood == 1):
            return 'happy'
        if(self.__mood == 2):
            return 'hungry'
        if(self.__mood == 3):
            return 'sleepy'

