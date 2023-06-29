with open("day11.txt") as file:
    calories = file.readlines()

sum_of_calories = 0
calories_each_deer_carries = []

for i in range(len(calories)):
    calories[i] = calories[i].strip()
    if calories[i] != '':
        sum_of_calories += int(calories[i])
    else:
        calories_each_deer_carries.append(sum_of_calories)
        sum_of_calories = 0

calories_each_deer_carries.append(sum_of_calories)

calories_each_deer_carries.sort(reverse = True)
print(sum(calories_each_deer_carries[:3]))