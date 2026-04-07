extends Node3D

"""
NOTE:
	I dunno if I should add sunlight mechanic

MECHANIC:
if water gets low, then health goes down
if health gets low, then happiness goes down

feeding fertilizer heals the plant and slightly gives the plant hapiness
watering plant increase water level to max which then allows a slow healing

TLDR: fertilizer = short temp fix, water = long term fix
"""

var health := 100.0
var water := 100.0
var happiness := 100.0


func update_stats():
	water -= 10

	if water <= 20:
		health -= 3
	else:
		health += 2
	
	if health <= 50:
		happiness -= 5
	else:
		happiness += 5

	health = clamp(health, 0, 100)
	water = clamp(water, 0, 100)
	happiness = clamp(happiness, 0, 100)
