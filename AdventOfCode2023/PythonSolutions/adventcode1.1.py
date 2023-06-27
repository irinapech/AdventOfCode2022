with open("day11.txt") as file:
    calories = file.readlines()

sum_of_calories = 0
max_calories = 0

for i in range(len(calories)):
    calories[i] = calories[i].strip()
    if calories[i] != '':
        sum_of_calories += int(calories[i])
    else:
        if sum_of_calories > max_calories:
            max_calories = sum_of_calories
        sum_of_calories = 0

print(f"{max_calories = }")