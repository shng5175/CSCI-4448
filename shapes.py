class Shape():

    def __init__(self, x, y, z):
        self.x = x #x coordinate
        self.y = y #y coordinate
        self.z = z #used to sort shapes, background shapes first
        self.type = None #type of shape (circle, triangle, square, etc..)


    def getZ(self):
        return self.z #get z in order to sort shapes


    def display(self):
        print(self.type, "is displayed at ", self.x, self.y)


#subclass of Shape, allows instantiation of Circle objects
class Circle(Shape):
    def __init__(self, x, y, z, r):
        Shape.__init__(self, x, y, z)
        self.type = 'circle'
        self.radius = r #set radius of the circle


#subclass of Shape, allows instantiation of Triangle objects
class Triangle(Shape):
    def __init__(self, x, y, z):
        Shape.__init__(self, x, y, z)
        self.type = 'triangle'


#subclass of Shape, allows instantiation of Square objects
class Square(Shape):
    def __init__(self, x, y, z):
        Shape.__init__(self, x, y, z)
        self.type = 'square'

#sorting function, sorts shapes in database by z
def sort(data):
    data.sort(key=lambda x: x.z)
    return data


a = Circle(5, 5, 10, 1)
b = Triangle( 1, 2, 9)
c = Square(10, 11, 7)

database = []
database.append(a)
database.append(b)
database.append(c)

database = sort(database)

for shape in database:
    shape.display()
