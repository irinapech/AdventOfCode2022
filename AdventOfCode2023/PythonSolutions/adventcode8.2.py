with open("day8.txt") as file:
    forest = file.readlines()

forest_int = [[int(x) for x in tree_line.strip()] for tree_line in forest]

forest_height = len(forest_int)
forest_width = len(forest_int[0])

scenic_scores = []

def get_number_of_seen_trees_from_side(trees_from_side, range_of_trees):
    number_of_seen_trees = 0
    for i in range_of_trees:
            number_of_seen_trees += 1
            if trees_from_side[i] >= central_tree:
                break
    return number_of_seen_trees

for i in range(1, forest_height - 1):
    for j in range(1, forest_width - 1):
        scenic_score = 1
        central_tree = forest_int[i][j]

        trees_to_left = [forest_int[i][k] for k in range(j)]
        trees_to_right = [forest_int[i][k] for k in range(j + 1, forest_width)]
        trees_above = [forest_int[k][j] for k in range(i)]
        trees_below = [forest_int[k][j] for k in range(i + 1, forest_height)]

        scenic_score *= get_number_of_seen_trees_from_side(trees_to_left, range(len(trees_to_left) - 1, -1, -1))
        scenic_score *= get_number_of_seen_trees_from_side(trees_to_right, range(len(trees_to_right)))        
        scenic_score *= get_number_of_seen_trees_from_side(trees_above, range(len(trees_above) - 1, -1, -1))
        scenic_score *= get_number_of_seen_trees_from_side(trees_below, range(len(trees_below)))

        scenic_scores.append(scenic_score)

print(f"{max(scenic_scores) = }")