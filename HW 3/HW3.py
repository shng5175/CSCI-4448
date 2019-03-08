##### Please ignore all the commneted out print statements, those are just there for me to make sure everything is passing correctly #####

import numpy as np 
from random import randint

class Store:
        #manage each customer's rental and calculate revenue
        def checkout(self, customers, tools):
                rentals = []
                revenue = 0
                for i in range(len(customers)):
                        if (len(tools) >= 3):
                                rental = customers[i].rent(tools)
                                #print (rental[0])
                                #create a rental for each customer
                                rent = Rental()
                                rentals = rent.create(rental[0], customers[i].daysRented)
                                #print(rentals, customers[i].daysRented)
                                for j in range(len(rentals)):
                                        revenue += (rentals[j].price * customers[i].daysRented)
                return revenue

#Create a record of each customer ental
class Rental():
	def create(self, toolsRented, daysRented): 
		rentals = []
		for j in range(len(toolsRented)):
                    #print(toolsRented)
                    rentals.append(toolsRented[j])
		return (rentals)

#Define a tool class
class Tool():
    def __init__(self, name, category, price):
        self.name = name
        self.category = category
        self.price = price

#The following are the 5 tool types derived from the tool class
class Painting(Tool):
    def __init__(self, name, category, price):
        Tool.__init__(self, name, category, price)

class Concrete(Tool):
    def __init__(self, name, category, price):
        Tool.__init__(self, name, category, price)

class Plumbing(Tool):
    def __init__(self, name, category, price):
        Tool.__init__(self, name, category, price)

class Woodwork(Tool):
    def __init__(self, name, category, price):
        Tool.__init__(self, name, category, price)

class Yardwork(Tool):
    def __init__(self, name, category, price):
        Tool.__init__(self, name, category, price)

#Generate a random tool list consisting of 20 tools
class toolFactory():
	def create(self):
            tools = []
            for i in range(0, 20):
                rand = randint(0,5)
                if rand == 0:
                        tools.append(Painting("Tool-" +str(i), "Painting", 3))
                elif rand == 1:
                        tools.append(Concrete("Tool-" +str(i), "Concrete", 5))
                elif rand == 2:
                        tools.append(Plumbing("Tool-" +str(i), "Plumbing", 8))
                elif rand == 3:
                        tools.append(Woodwork("Tool-" +str(i), "Woodwork", 13))
                else:
                        tools.append(Yardwork("Tool-" +str(i), "Yardwork", 21))
                i += 1
            #print (tools)
            return tools

#Define a customer class
class Customer ():
    def __init__(self, name, typeOf):
        self.name = name
        self.typeOf = typeOf
    def rent(self):
        pass

#The following are the three customer types derived from the main customer class
class Casual(Customer):
	def __init__(self, name):
		self.name = name
		self.typeOf = "Casual"
		#Each customer has a different range for days rented
		#Randomly generate a number within that range for each customer
		self.daysRented = randint(1, 2)

	def rent(self, tools):
                #Each customer also has a different range for ho wmany tools can be rented
                #Randomly generate a number of tools to rent
		numTools = randint(1, 2)
		toolsRented = []
		for i in range(numTools):
			toolsRented.append(tools.pop(0))
		#print(toolsRented, tools)
		return (toolsRented, tools)

class Regular(Customer):
	def __init__(self, name):
		self.name = name
		self.typeOf = "Regular"
		self.daysRented = randint(3, 5)

	def rent(self, tools):
		numTools = randint(1, 3)
		toolsRented = []
		for i in range(numTools):
			toolsRented.append(tools.pop(0))
		#print(toolsRented, tools)
		return (toolsRented, tools)


class Business(Customer): 
	def __init__(self, name):
		self.name = name
		self.typeOf = "Business"
		self.daysRented = 7

	def rent(self, tools):
		numTools = 3
		toolsRented = []
		for i in range(numTools):
			toolsRented.append(tools.pop(0))
		#print(toolsRented, tools)
		return (toolsRented, tools)

#Generate 10 customers with a random type(regular, casual, or business)
class customerFactory:
	def Regular(name):
		return(Regular(name))
	def Casual(name):
		return(Casual(name))
	def Business(name):
		return(Business(name))
	def create(self):
		customers = []
		for i in range(0, 10):
			randint = np.random.choice(3, 1)
			if randint == 0:
			    customers.append(Casual("Customer" +str(i)))
			elif randint == 1:
                            customers.append(Business("Customer" +str(i)))
			else:
                            customers.append(Regular("Customer" +str(i)))
			i += 1
		#print(customers)
		return customers

#Single simulation of a single day at the store
def simulation():
        tools = toolFactory().create()
        customers = customerFactory().create()
        #print(tools)
        store = Store()
        merp = store.checkout(customers, tools)
        print ("Daily Revenue: $", merp)

#Simulate 35 days at the store
for i in range(0, 35):
        simulation()
		
