extends Node3D

# Camera
@onready var top_camera = $TopDownCamera
# System
@onready var stats = $StatsSystem

# UI
@onready var plant_panel = $UI/PlantPanel
@onready var water_bar = $UI/MainPanel/VBoxContainer/WaterBar
@onready var health_bar = $UI/MainPanel/VBoxContainer/HealthBar
@onready var happiness_bar = $UI/MainPanel/VBoxContainer/HappinessBar

"""
TODO:
- stages (seed -> ripe fruit) including the script and animation
- tamagotchi feature (taking care of plant)
- ui/ux for navigation
- setup camera system

"""


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	print("Game Starting...")
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta: float) -> void:
#	pass

func _on_stats_timer_timeout() -> void:
	stats.update_stats()	
	water_bar.value = stats.water
	health_bar.value = stats.health
	happiness_bar.value = stats.happiness
	pass # Replace with function body.
