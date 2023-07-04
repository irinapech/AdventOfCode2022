with open("day5python.txt") as file:
    calories = file.readlines()

print(calories)

offset = 1
chars_in_column = 4

crates = [[]]

for i in range(len(calories)):
    for j in range(len(calories[i])):
        if calories[i][j].isalpha:
            crate_location = (j - offset) // chars_in_column
            try:
                crates[crate_location].append(calories[i][j])
            except:
                for k in range(len(crates), crate_location + 1):
                    crates.append('0')
                crates[crate_location].append(calories[i][j])
            print(crates)