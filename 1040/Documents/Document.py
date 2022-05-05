class Document: 

    def __init__(self, title, body, author):
        self.__title = title
        self.__body = body
        self.__author = author 

    def get_Title(self):
        return self.__title
    
    def get_Body(self):
        return self.__body
    
    def get_Author(self):
        return self.__author