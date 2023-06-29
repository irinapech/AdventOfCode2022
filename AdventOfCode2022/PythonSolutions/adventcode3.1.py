with open("day31.txt") as file:
    all_rucksacks = file.readlines()

upper_letters_difference = 38
lower_letters_difference = 96

sum_of_priorities = 0

for i in range(len(all_rucksacks)):
    all_rucksacks[i] = all_rucksacks[i].strip()

    middle_of_rucksack = int(len(all_rucksacks[i]) / 2)

    first_compartment = all_rucksacks[i][:middle_of_rucksack]
    second_compartment = all_rucksacks[i][middle_of_rucksack:]

    common_items = set([item for item in first_compartment if item in second_compartment])

    for item in common_items:
        if item.isupper():
            priority = ord(item) - upper_letters_difference
        else:
            priority = ord(item) - lower_letters_difference
        sum_of_priorities += priority
    
print(f"{sum_of_priorities}")