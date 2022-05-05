from Document import Document

def getInput():
    print('Welcome to the document generator!')
    documents = []

    again = True 
    while again:
        title = input('Enter title: ')
        body = input('Enter body: ')
        author = input('Enter author: ')
      
        elements = Document(title, body, author)
        documents.append(elements)
    
        again = input('Would you like to add more documents? (y/n) ')
        if again != 'y':
            again = False
        
    return documents

def getDocument(documents):
    print('\n' + 'Document List:')

    for x in documents:
        docTitle = x.get_Title()
        docBody = x.get_Body()
        docAuthor = x.get_Author()
        print('\n' + docTitle + '\n' + docBody + '\n' + docAuthor + '\n')
        print('----------------------------')

def main():
    inputs = getInput()
    getDocument(inputs)
    input('Press ENTER to exit')    

main()