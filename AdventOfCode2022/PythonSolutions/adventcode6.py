datastream_buffer = []
with open("day6.txt") as file:
    datastream_buffer = file.readline()

#subsequent_deifferent_chars = 4 - variable for the first part of day 6
subsequent_deifferent_chars = 14
print(datastream_buffer)

for i in range(len(datastream_buffer[0])):
    marker = datastream_buffer[0][i:i+subsequent_deifferent_chars]
    print(marker)
    if len(set(marker)) == len(marker):
        print(i + subsequent_deifferent_chars)
        break