#class_name DragonController
extends Node2D

@export var dragon_bones: DragonBones;

var _amature: DragonBonesArmature;

func _ready() -> void:
	_amature = dragon_bones.amature;
