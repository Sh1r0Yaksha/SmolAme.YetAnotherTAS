﻿using HarmonyLib;
using SmolAme.YetAnotherTAS.Components;
using TAS.Core.Input.Commands;
using TAS.Core.Utils;
using UnityEngine;

namespace SmolAme.YetAnotherTAS.Commands;

public class CharacterCommand {
    private static string GetCharacterName(int index) {
        return index switch {
            1 => "bubba",
            2 => "bloop",
            3 => "hosoinu",
            4 => "onigiri",
            5 => "stache",
            6 => "guraWeird",
            7 => "ushi",
            8 => "shuba",
            9 => "catGura",
            10 => "coco",
            11 => "ollie",
            12 => "reine",
        };
    }

    [TasCommand("Character", LegalInMainGame = false)]
    private static void Character(string[] args) {

        //if (VersionText.Version() <= 210218) {
        //    return;
        //    }
        if (args.IsEmpty()) {
            return;
        }
        if (int.TryParse(args[0], out int index) && PlayerScript.player.characterPacks != null) {
            index = Mathf.Clamp(index, 1, PlayerScript.player.characterPacks.Count) - 1;
            MainScript.currentCharacter = index;
            PlayerPrefs.SetInt("character", MainScript.currentCharacter);
            PlayerScript.player.currentCharacter = MainScript.currentCharacter;
        }

    }
}