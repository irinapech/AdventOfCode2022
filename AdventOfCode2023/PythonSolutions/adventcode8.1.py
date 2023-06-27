with open("day8.txt") as file:
    forest = file.readlines()

forest_int = [[int(x) for x in tree_line.strip()] for tree_line in forest]

forest_width = len(forest_int[0])
forest_height = len(forest_int)

visible_trees = 0

for i in range(1, forest_height - 1):
    for j in range(1, forest_width - 1):
        central_tree = int(forest_int[i][j])

        trees_to_left = [forest_int[i][k] for k in range(j)]
        trees_to_right = [forest_int[i][k] for k in range(j + 1, forest_width)]
        trees_below = [forest_int[k][j] for k in range(i + 1, forest_height)]
        trees_above = [forest_int[k][j] for k in range(i)]

        if max(trees_to_left) < central_tree \
                    or max(trees_to_right) < central_tree \
                    or max(trees_below) < central_tree \
                    or max(trees_above) < central_tree:
            print(f"visible tree: {forest_int[i][j]} at position [{i}][{j}]")
            visible_trees += 1

visible_trees += (forest_height + forest_width) * 2 - 4

print(visible_trees)