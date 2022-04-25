from Animals import Animals

def main():

    print('Welcome to the animal generator!')
    print('This program creates Animal objects.')

    animalTypes = []
    animalNames = []

    repeat = True
    while repeat:

        types = input('\n' + 'What type of animal would you like to create? ')
        names = input("What is the animal's name? ")

        if len(types) == 0 or len(names) == 0:
            print('\n' + 'Please enter value for both fields' + '\n')
            repeat = True
        else:
            animalTypes.append(types.capitalize())
            animalNames.append(names.capitalize())
            

            repeat = input('\n' +'Would you like to add more animals (y/n)?')
            if(repeat != 'y'):
                repeat = False
    
    print('\n' + 'Animal List:')
    for x in range(len(animalTypes)):
        a = Animals(animalNames[x], animalTypes[x], ' ')
        print(a.get_name() + ' the ' + a.get_animalType() + ' is ' + a.checkMood())
    
    input('Press ENTER to exit')
        
main()