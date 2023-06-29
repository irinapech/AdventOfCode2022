with open("day3.txt") as file:
    all_rucksacks = file.readlines()

upper_letters_difference = 38
lower_letters_difference = 96

sum_of_priorities = 0

for i in range(0, len(all_rucksacks) - 2, 3):
    first_elf = all_rucksacks[i].strip()
    second_elf = all_rucksacks[i + 1].strip()
    third_elf = all_rucksacks[i + 2].strip()

    common_items = set([item for item in first_elf if item in second_elf and item in third_elf])

    for item in common_items:
        if item.isupper():
            priority = ord(item) - upper_letters_difference
        else:
            priority = ord(item) - lower_letters_difference
        sum_of_priorities += priority
    
print(f"{sum_of_priorities}")