employee_id = {'Huzair': 200, 'Ahmed': 300}
employee_id['guido'] = 400
print(employee_id)

#access
print(employee_id['Huzair'])

#delete 
del employee_id['Ahmed']

#modify
employee_id['Surya'] = 500

print(employee_id)

#list
print("List Output",list(employee_id))

#sort
print(sorted(employee_id))

print('Surya' in employee_id)

print('Vishal' not in employee_id)


#nested Dictionary
Dict = {'Huzair': {1: 'Presidio'},
        'Employee': {'Name': 'Huzair'}}

print(Dict['Huzair'])
print(Dict['Huzair'][1])
print(Dict['Employee']['Name'])

