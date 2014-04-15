//Maya ASCII 2013 scene
//Name: soupladle_mesh_001.ma
//Last modified: Wed, Apr 16, 2014 01:37:20 PM
//Codeset: 1252
requires maya "2013";
requires "stereoCamera" "10.0";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2013";
fileInfo "version" "2013 x64";
fileInfo "cutIdentifier" "201209210409-845513";
fileInfo "osv" "Microsoft Windows 7 Enterprise Edition, 64-bit Windows 7 Service Pack 1 (Build 7601)\n";
fileInfo "license" "education";
createNode transform -s -n "persp";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -116.28759677613904 70.31205265833016 117.3385563721197 ;
	setAttr ".r" -type "double3" 347.06161546776309 -46.600000000000506 -3.4717790289986227e-015 ;
createNode camera -s -n "perspShape" -p "persp";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999986;
	setAttr ".coi" 177.97553179892955;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" 2.6867983329639382 0.092715711458410399 1.8453727846742227 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 100.1 0 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
createNode transform -s -n "front";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 100.1 ;
createNode camera -s -n "frontShape" -p "front";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
createNode transform -s -n "side";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 100.1 0.59574468085106336 -4.1276595744680877 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
createNode transform -n "pCylinder1";
	setAttr ".t" -type "double3" 6.767377352452197 0.21434637162465045 3.5438788173477609 ;
createNode transform -n "transform2" -p "pCylinder1";
	setAttr ".v" no;
createNode mesh -n "pCylinderShape1" -p "transform2";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "pCylinder2";
	setAttr ".t" -type "double3" 6.767377352452197 0.21434637162465045 3.5438788173477609 ;
	setAttr ".s" -type "double3" 0.91644290293530517 0.97907523328916257 0.91644290293530517 ;
createNode transform -n "transform1" -p "pCylinder2";
	setAttr ".v" no;
createNode mesh -n "pCylinderShape2" -p "transform1";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".iog[0].og[0].gcl" -type "componentList" 1 "f[0:63]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 142 ".uvst[0].uvsp[0:141]" -type "float2" 0.375 0.3125 0.40625
		 0.3125 0.4375 0.3125 0.46875 0.3125 0.5 0.3125 0.53125 0.3125 0.5625 0.3125 0.59375
		 0.3125 0.625 0.3125 0.375 0.40648496 0.40625 0.40648496 0.4375 0.40648496 0.46875
		 0.40648496 0.5 0.40648496 0.53125 0.40648496 0.5625 0.40648496 0.59375 0.40648496
		 0.625 0.40648496 0.375 0.50046992 0.40625 0.50046992 0.4375 0.50046992 0.46875 0.50046992
		 0.5 0.50046992 0.53125 0.50046992 0.5625 0.50046992 0.59375 0.50046992 0.625 0.50046992
		 0.375 0.59445488 0.40625 0.59445488 0.4375 0.59445488 0.46875 0.59445488 0.5 0.59445488
		 0.53125 0.59445488 0.5625 0.59445488 0.59375 0.59445488 0.625 0.59445488 0.375 0.68843985
		 0.40625 0.68843985 0.4375 0.68843985 0.46875 0.68843985 0.5 0.68843985 0.53125 0.68843985
		 0.5625 0.68843985 0.59375 0.68843985 0.625 0.68843985 0.59375 0.44259578 0.5625 0.44259578
		 0.53125 0.44259578 0.5 0.44259578 0.46875 0.44259578 0.4375 0.44259578 0.40625 0.44259578
		 0.625 0.44259578 0.375 0.44259578 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1
		 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0
		 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0
		 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 0.5 1 0 0 1 0 0.5 1 0 0 1 0 0.5
		 1 0 0 1 0 0.5 1 0 0 1 0 0.5 1 0 0 1 0 0.5 1 0 0 1 0 0.5 1 0 0 1 0 0.5 1;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[32:39]" -type "float3"  0 0.015088458 0 0 0.015088458 
		0 0 0.015088458 0 0 0.015088458 0 0 0.015088458 0 0 0.015088458 0 0 0.015088458 0 
		0 0.015088458 0;
	setAttr -s 65 ".vt[0:64]"  0.21215582 0.024061471 -0.21215582 0 0.024061471 -0.30003357
		 -0.21215582 0.024061471 -0.21215582 -0.30003357 0.024061471 0 -0.21215582 0.024061471 0.21215582
		 0 0.024061471 0.30003357 0.21215582 0.024061471 0.21215582 0.30003357 0.024061471 0
		 0.21215582 0.4149349 -0.21215582 0 0.4149349 -0.30003357 -0.21215582 0.4149349 -0.21215582
		 -0.30003357 0.4149349 0 -0.21215582 0.4149349 0.21215582 0 0.4149349 0.30003357 0.21215582 0.4149349 0.21215582
		 0.30003357 0.4149349 0 0.13805485 0.57146978 -0.13805509 0 0.57146978 -0.19523931
		 -0.13805485 0.57146978 -0.13805509 -0.19523907 0.57146978 0 -0.13805485 0.57146978 0.13805509
		 0 0.57146978 0.19523931 0.13805485 0.57146978 0.13805509 0.19523954 0.57146978 0
		 0.15729141 0.60604203 -0.15729117 0 0.60604203 -0.22244334 -0.15729141 0.60604203 -0.15729117
		 -0.22244358 0.60604203 0 -0.15729141 0.60604203 0.15729117 0 0.60604203 0.22244334
		 0.15729141 0.60604203 0.15729117 0.22244358 0.60604203 0 0.15729141 0.69131422 -0.15729117
		 0 0.69131422 -0.22244334 -0.15729141 0.69131422 -0.15729117 -0.22244358 0.69131422 0
		 -0.15729141 0.69131422 0.15729117 0 0.69131422 0.22244334 0.15729141 0.69131422 0.15729117
		 0.22244358 0.69131422 0 0.27048779 0.47507861 0 0.19126368 0.47507861 0.19126368
		 0 0.47507861 0.27048755 -0.19126368 0.47507861 0.19126368 -0.27048779 0.47507861 0
		 -0.19126368 0.47507861 -0.19126368 0 0.47507861 -0.27048755 0.19126368 0.47507861 -0.19126368
		 0.18096924 -0.049034655 -0.180969 0 -0.049034655 -0.25592875 -0.18096924 -0.049034655 -0.180969
		 -0.25592899 -0.049034655 0 -0.18096924 -0.049034655 0.180969 0 -0.049034655 0.25592875
		 0.18096924 -0.049034655 0.180969 0.25592899 -0.049034655 0 0.15074635 -0.081347942 -0.15074611
		 0 -0.081347942 -0.21318722 -0.15074635 -0.081347942 -0.15074611 -0.21318722 -0.081347942 0
		 -0.15074635 -0.081347942 0.15074611 0 -0.081347942 0.21318722 0.15074635 -0.081347942 0.15074611
		 0.21318722 -0.081347942 0 4.4408921e-016 -0.081347942 0;
	setAttr -s 128 ".ed[0:127]"  0 1 0 1 2 0 2 3 0 3 4 0 4 5 0 5 6 0 6 7 0
		 7 0 0 8 9 1 9 10 1 10 11 1 11 12 1 12 13 1 13 14 1 14 15 1 15 8 1 16 17 1 17 18 1
		 18 19 1 19 20 1 20 21 1 21 22 1 22 23 1 23 16 1 24 25 1 25 26 1 26 27 1 27 28 1 28 29 1
		 29 30 1 30 31 1 31 24 1 32 33 0 33 34 0 34 35 0 35 36 0 36 37 0 37 38 0 38 39 0 39 32 0
		 0 8 0 1 9 0 2 10 0 3 11 0 4 12 0 5 13 0 6 14 0 7 15 0 8 47 0 9 46 0 10 45 0 11 44 0
		 12 43 0 13 42 0 14 41 0 15 40 0 16 24 0 17 25 0 18 26 0 19 27 0 20 28 0 21 29 0 22 30 0
		 23 31 0 24 32 0 25 33 0 26 34 0 27 35 0 28 36 0 29 37 0 30 38 0 31 39 0 40 23 0 41 22 0
		 40 41 1 42 21 0 41 42 1 43 20 0 42 43 1 44 19 0 43 44 1 45 18 0 44 45 1 46 17 0 45 46 1
		 47 16 0 46 47 1 47 40 1 0 48 0 1 49 0 48 49 0 2 50 0 49 50 0 3 51 0 50 51 0 4 52 0
		 51 52 0 5 53 0 52 53 0 6 54 0 53 54 0 7 55 0 54 55 0 55 48 0 48 56 0 49 57 0 56 57 0
		 50 58 0 57 58 0 51 59 0 58 59 0 52 60 0 59 60 0 53 61 0 60 61 0 54 62 0 61 62 0 55 63 0
		 62 63 0 63 56 0 56 64 0 57 64 0 58 64 0 59 64 0 60 64 0 61 64 0 62 64 0 63 64 0;
	setAttr -s 64 -ch 248 ".fc[0:63]" -type "polyFaces" 
		f 4 0 41 -9 -41
		mu 0 4 0 1 10 9
		f 4 1 42 -10 -42
		mu 0 4 1 2 11 10
		f 4 2 43 -11 -43
		mu 0 4 2 3 12 11
		f 4 3 44 -12 -44
		mu 0 4 3 4 13 12
		f 4 4 45 -13 -45
		mu 0 4 4 5 14 13
		f 4 5 46 -14 -46
		mu 0 4 5 6 15 14
		f 4 6 47 -15 -47
		mu 0 4 6 7 16 15
		f 4 7 40 -16 -48
		mu 0 4 7 8 17 16
		f 4 8 49 86 -49
		mu 0 4 9 10 51 53
		f 4 9 50 84 -50
		mu 0 4 10 11 50 51
		f 4 10 51 82 -51
		mu 0 4 11 12 49 50
		f 4 11 52 80 -52
		mu 0 4 12 13 48 49
		f 4 12 53 78 -53
		mu 0 4 13 14 47 48
		f 4 13 54 76 -54
		mu 0 4 14 15 46 47
		f 4 14 55 74 -55
		mu 0 4 15 16 45 46
		f 4 15 48 87 -56
		mu 0 4 16 17 52 45
		f 4 16 57 -25 -57
		mu 0 4 18 19 28 27
		f 4 17 58 -26 -58
		mu 0 4 19 20 29 28
		f 4 18 59 -27 -59
		mu 0 4 20 21 30 29
		f 4 19 60 -28 -60
		mu 0 4 21 22 31 30
		f 4 20 61 -29 -61
		mu 0 4 22 23 32 31
		f 4 21 62 -30 -62
		mu 0 4 23 24 33 32
		f 4 22 63 -31 -63
		mu 0 4 24 25 34 33
		f 4 23 56 -32 -64
		mu 0 4 25 26 35 34
		f 4 24 65 -33 -65
		mu 0 4 27 28 37 36
		f 4 25 66 -34 -66
		mu 0 4 28 29 38 37
		f 4 26 67 -35 -67
		mu 0 4 29 30 39 38
		f 4 27 68 -36 -68
		mu 0 4 30 31 40 39
		f 4 28 69 -37 -69
		mu 0 4 31 32 41 40
		f 4 29 70 -38 -70
		mu 0 4 32 33 42 41
		f 4 30 71 -39 -71
		mu 0 4 33 34 43 42
		f 4 31 64 -40 -72
		mu 0 4 34 35 44 43
		f 4 -75 72 -23 -74
		mu 0 4 46 45 25 24
		f 4 -77 73 -22 -76
		mu 0 4 47 46 24 23
		f 4 -79 75 -21 -78
		mu 0 4 48 47 23 22
		f 4 -81 77 -20 -80
		mu 0 4 49 48 22 21
		f 4 -83 79 -19 -82
		mu 0 4 50 49 21 20
		f 4 -85 81 -18 -84
		mu 0 4 51 50 20 19
		f 4 -87 83 -17 -86
		mu 0 4 53 51 19 18
		f 4 -88 85 -24 -73
		mu 0 4 45 52 26 25
		f 4 -1 88 90 -90
		mu 0 4 54 55 56 57
		f 4 -2 89 92 -92
		mu 0 4 58 59 60 61
		f 4 -3 91 94 -94
		mu 0 4 62 63 64 65
		f 4 -4 93 96 -96
		mu 0 4 66 67 68 69
		f 4 -5 95 98 -98
		mu 0 4 70 71 72 73
		f 4 -6 97 100 -100
		mu 0 4 74 75 76 77
		f 4 -7 99 102 -102
		mu 0 4 78 79 80 81
		f 4 -8 101 103 -89
		mu 0 4 82 83 84 85
		f 4 -91 104 106 -106
		mu 0 4 86 87 88 89
		f 4 -93 105 108 -108
		mu 0 4 90 91 92 93
		f 4 -95 107 110 -110
		mu 0 4 94 95 96 97
		f 4 -97 109 112 -112
		mu 0 4 98 99 100 101
		f 4 -99 111 114 -114
		mu 0 4 102 103 104 105
		f 4 -101 113 116 -116
		mu 0 4 106 107 108 109
		f 4 -103 115 118 -118
		mu 0 4 110 111 112 113
		f 4 -104 117 119 -105
		mu 0 4 114 115 116 117
		f 3 -107 120 -122
		mu 0 3 118 119 120
		f 3 -109 121 -123
		mu 0 3 121 122 123
		f 3 -111 122 -124
		mu 0 3 124 125 126
		f 3 -113 123 -125
		mu 0 3 127 128 129
		f 3 -115 124 -126
		mu 0 3 130 131 132
		f 3 -117 125 -127
		mu 0 3 133 134 135
		f 3 -119 126 -128
		mu 0 3 136 137 138
		f 3 -120 127 -121
		mu 0 3 139 140 141;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "soupladle_mesh_001";
	setAttr ".t" -type "double3" 0.45930515104842495 2.2214418247844874 0.56776810781733378 ;
	setAttr ".r" -type "double3" 0 -22.454351522050185 0 ;
	setAttr ".s" -type "double3" 73.777438501226399 63.540995600542139 73.777438501226399 ;
createNode mesh -n "soupladle_mesh_001Shape" -p "soupladle_mesh_001";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 212 ".uvst[0].uvsp[0:211]" -type "float2" 0.45833334 0 0.54166669
		 0 0.45833334 0.125 0.54166669 0.125 0.45833334 0.25 0.54166669 0.25 0.375 0.33333334
		 0.45833334 0.33333334 0.54166669 0.33333334 0.625 0.33333334 0.375 0.41666669 0.45833334
		 0.41666669 0.54166669 0.41666669 0.625 0.41666669 0.45833334 0.5 0.54166669 0.5 0.45833334
		 0.625 0.54166669 0.625 0.45833334 0.75 0.54166669 0.75 0.375 0.83333331 0.45833334
		 0.83333331 0.54166669 0.83333331 0.625 0.83333331 0.375 0.91666663 0.45833334 0.91666663
		 0.54166669 0.91666663 0.625 0.91666663 0.45833334 0.99999994 0.54166669 0.99999994
		 0.79166669 0 0.70833337 0 0.79166669 0.125 0.70833337 0.125 0.79166669 0.25 0.70833337
		 0.25 0.20833334 0 0.29166669 0 0.20833334 0.125 0.29166669 0.125 0.20833334 0.25
		 0.29166669 0.25 0.50070512 0.41666669 0.50070512 0.5 0.50070512 0.625 0.50070512
		 0.75 0.50070512 0.83333331 0.50070512 0.91666663 0.50070512 0 0.50070512 0.99999988
		 0.50070512 0.125 0.50070512 0.25 0.50070512 0.33333334 0.45833334 0.37508643 0.2499136
		 0.25 0.375 0.37508643 0.2499136 0.125 0.2499136 0 0.375 0.87491357 0.45833334 0.87491357
		 0.50070512 0.87491357 0.54166669 0.87491357 0.625 0.87491357 0.75008643 0 0.75008643
		 0.125 0.625 0.37508643 0.75008643 0.25 0.54166669 0.37508643 0.50070512 0.030185454
		 0.45833337 0.030185454 0.29166669 0.030185454 0.2499136 0.030185454 0.20833334 0.030185454
		 0.45833337 0.71981454 0.50070512 0.71981454 0.54166669 0.71981454 0.79166663 0.030185454
		 0.75008643 0.030185454 0.70833337 0.030185454 0.54166669 0.030185454 0 0 1 0 1 1
		 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0
		 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1
		 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0
		 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0.54166669 0.37508643
		 0.625 0.37508643 0.625 0.41666669 0.54166669 0.41666669 0.54166669 0.37508643 0.625
		 0.37508643 0.625 0.41666669 0.54166669 0.41666669 0.54166669 0.37508643 0.625 0.37508643
		 0.625 0.41666669 0.54166669 0.41666669 0.54166669 0.37508643 0.54166669 0.41666669
		 0.625 0.41666669 0.625 0.37508643 0.54166669 0.37508643 0.54166669 0.41666669 0.625
		 0.41666669 0.625 0.37508643 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1 0 1 1 0 1 0 0 1
		 0 1 1 0 1 0.54166669 0.37508643 0.54166669 0.41666669 0.625 0.41666669 0.625 0.37508643
		 0.54166669 0.37508643 0.54166669 0.41666669 0.625 0.41666669 0.625 0.37508643 0.54166669
		 0.37508643 0.54166669 0.41666669 0.625 0.41666669 0.625 0.37508643 0 0 1 0 1 1 0
		 1;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 118 ".vt[0:117]"  -0.045711517 -0.022006631 0.062521935 0.045755386 -0.022006631 0.062521935
		 -0.088781357 0.045266092 0.12143111 0.088866234 0.045266092 0.12143087 -0.10353518 0.13336155 0.1416111
		 0.10363436 0.13336155 0.1416111 -0.12986636 0.13336155 0.11249709 -0.11021209 0.14054194 0.11982
		 0.11031985 0.14054194 0.11981988 0.12996578 0.13336155 0.11249709 -0.12986612 0.13336155 -0.10621226
		 -0.11021209 0.14054194 -0.11299574 0.11116266 0.14066708 -0.11095583 0.12043595 0.13336155 -0.1214273
		 -0.10353518 0.13336155 -0.13532615 0.088432312 0.13336155 -0.13655007 -0.088781118 0.045266092 -0.11604154
		 0.072569609 0.045266092 -0.11991429 -0.045711279 -0.022006631 -0.059746981 0.029511929 -0.022006631 -0.063491583
		 -0.057336569 -0.022006631 -0.046893001 -0.04571104 -0.022006631 -0.046893239 0.040258408 -0.023309469 -0.049841046
		 0.049375296 -0.022006631 -0.053257465 -0.057336569 -0.022006631 0.049667954 -0.045711279 -0.022006631 0.049667954
		 0.045755386 -0.022006631 0.049667954 0.057380438 -0.022006631 0.049667954 0.10191512 0.045266092 -0.10629165
		 0.11144471 0.045266092 0.096465707 -0.11135983 0.045266092 -0.091076374 -0.11136103 0.045266092 0.096466064
		 0.0027756691 0.14066827 -0.16439152 0.0025560856 0.13336155 -0.17977774 0.002191782 0.045266092 -0.15282094
		 0.0011286736 -0.022006631 -0.074129581 0.0011279583 -0.023309469 -0.061275482 0.0011279583 -0.022006631 0.064794064
		 0.0011284351 -0.022006631 0.077648044 0.002191782 0.045266092 0.15633941 0.0025560856 0.13336155 0.18329632
		 0.0027754307 0.14054063 0.16790986 -0.15591455 0.14054063 -0.00036025047 -0.16928959 0.13336155 -0.00033175945
		 -0.14401197 0.045266092 -0.00028467178 -0.070223808 -0.022006631 -0.00014650822 -0.058598042 -0.022006631 -0.00014650822
		 0.0011284351 -0.022006631 -0.00014650822 0.061240196 -0.022006631 -9.2744827e-005
		 0.073253155 -0.022006631 -0.0001462698 0.14704299 0.045266092 -0.00028443336 0.17232037 0.13336155 -0.00033187866
		 0.15894437 0.14072451 -0.00036036968 0.001642704 -0.0030218661 0.11570704 -0.066542149 -0.0030218661 0.091013312
		 -0.083464861 -0.0030218661 0.072301745 -0.10591102 -0.0030218661 -0.00021326542 -0.083465099 -0.0030218661 -0.068262339
		 -0.066542149 -0.0030218661 -0.086973786 0.001642704 -0.0030218661 -0.11218858 0.053449869 -0.0030218661 -0.095729113
		 0.076651096 -0.0030218661 -0.080184937 0.10894203 -0.0030218661 -0.00021326542 0.083528519 -0.0030218661 0.072301745
		 0.066604614 -0.0030218661 0.091013432 -0.085571766 0.044479012 0.092978716 0.0021116734 0.044479012 0.12641335
		 -0.085571527 0.044479012 -0.08778429 0.002112627 0.043273389 -0.12289464 -0.11675167 0.044479012 -0.00027430058
		 0.08565402 0.044479012 0.092978716 0.11978078 0.044618964 -0.00027406216 0.085653782 0.043273389 -0.087784171
		 -0.054593086 -0.0013141036 0.059318662 0.0013482571 -0.0013141036 0.078523993 -0.054593086 -0.0013141036 -0.056004405
		 0.0013480186 -0.0012521744 -0.07500577 -0.071405411 -0.0013141036 -7.0333481e-005
		 0.0546453 -0.0013141036 0.059318662 0.074912548 -0.0012608469 -0.00026881695 0.0546453 -0.0012521744 -0.056004405
		 0.0013475418 -0.0012753904 -0.00053584576 0.14675927 0.34901136 -0.044861436 0.13478518 0.34903526 -0.045469403
		 0.1339736 0.34901136 -0.0744766 0.12517214 0.34903568 -0.063710093 0.1762414 0.5178566 -0.053156495
		 0.1642673 0.51788056 -0.053764701 0.16048002 0.5178566 -0.089971662 0.15167832 0.51788098 -0.079205394
		 0.27038026 1.059775591 -0.060403347 0.25022936 1.059799194 -0.057631731 0.23557544 1.059775591 -0.14329767
		 0.21859646 1.05979991 -0.12915182 0.13374639 0.29116815 -0.037047505 0.11900139 0.29116857 -0.067703962
		 0.12780333 0.29114419 -0.078470588 0.14572072 0.29114419 -0.036439657 0.1499579 0.18245775 -0.024141073
		 0.12177348 0.18245804 -0.087317348 0.13057542 0.18442011 -0.098083973 0.16193223 0.18442011 -0.023533106
		 0.2623719 1.074872375 -0.075267337 0.24973989 1.074879885 -0.073425174 0.24048607 1.074872494 -0.12727305
		 0.22985148 1.074880123 -0.11839139 0.14120483 0.23441976 -0.030243278 0.11970448 0.23442018 -0.077246904
		 0.12850618 0.23543274 -0.088013411 0.15317917 0.23543274 -0.029635549 0.23440075 0.96001261 -0.056919694
		 0.20627451 0.96001297 -0.11995494 0.22174764 0.95876521 -0.1334784 0.2530458 0.95876521 -0.059068799
		 0.23047781 0.93926436 -0.06764102 0.21152401 0.93926495 -0.10848117 0.22063756 0.93801719 -0.11937654
		 0.24276304 0.93801719 -0.067161679;
	setAttr -s 236 ".ed";
	setAttr ".ed[0:165]"  0 38 1 2 39 1 3 29 1 4 40 1 6 7 1 7 41 1 8 9 1 10 11 1
		 11 32 1 12 13 1 10 14 1 14 33 1 16 34 1 18 35 1 19 23 1 20 21 1 21 36 1 22 23 1 24 25 1
		 25 37 1 26 27 1 0 54 1 1 64 1 2 4 1 3 5 1 4 6 1 4 7 1 5 8 1 5 9 1 6 43 1 7 42 1 8 52 1
		 9 51 1 11 14 1 12 15 1 13 15 1 14 16 1 15 17 1 16 58 1 17 60 1 18 20 1 18 21 1 19 22 1
		 20 45 1 21 46 1 22 48 1 23 49 1 24 0 1 25 0 1 26 1 1 27 1 1 17 28 1 28 50 1 23 61 1
		 27 63 1 28 13 1 29 9 1 16 30 1 30 44 1 31 2 1 20 57 1 24 55 1 30 10 1 31 6 1 32 12 1
		 33 15 1 32 33 1 34 17 1 33 34 1 35 19 1 34 59 1 36 22 1 35 36 1 37 26 1 36 47 1 38 1 1
		 37 38 1 39 3 1 38 53 1 40 5 1 39 40 1 41 8 1 40 41 1 42 11 1 43 10 1 42 43 1 44 31 1
		 43 44 1 45 24 1 44 56 1 46 25 1 45 46 1 47 37 1 46 47 1 48 26 1 47 48 1 49 27 1 48 49 1
		 50 29 1 49 62 1 51 13 1 50 51 1 52 12 1 51 52 1 53 39 1 54 2 1 53 54 1 55 31 1 54 55 1
		 56 45 1 55 56 1 57 30 1 56 57 1 58 18 1 57 58 1 59 35 1 58 59 1 60 19 1 59 60 1 61 28 1
		 60 61 1 62 50 1 61 62 1 63 29 1 62 63 1 64 3 1 63 64 1 64 53 1 7 65 1 41 66 1 65 66 1
		 11 67 1 32 68 1 67 68 1 42 69 1 65 69 1 8 70 1 52 71 1 70 71 1 12 72 1 68 72 1 66 70 1
		 69 67 1 71 72 1 65 73 1 66 74 1 73 74 1 67 75 1 68 76 1 75 76 1 69 77 1 73 77 1 70 78 1
		 71 79 1 78 79 1 72 80 1 76 80 1 74 78 1 77 75 1 79 80 1 74 81 1 81 79 1 76 81 1 77 81 1
		 51 101 1 52 98 1;
	setAttr ".ed[166:235]" 82 83 1 13 100 0 82 84 1 12 99 1 85 84 1 83 85 1 82 86 0
		 83 87 1 86 87 1 84 88 0 86 88 1 85 89 1 89 88 1 87 89 1 86 117 0 87 114 1 90 91 1
		 88 116 0 90 92 1 89 115 1 93 92 1 91 93 1 94 83 1 95 85 1 94 95 1 96 84 0 95 96 1
		 97 82 0 96 97 1 97 94 1 98 106 1 99 107 1 98 99 1 100 108 0 99 100 1 101 109 0 100 101 1
		 101 98 1 90 102 1 91 103 1 102 103 1 92 104 1 102 104 1 93 105 1 105 104 1 103 105 1
		 106 94 1 107 95 1 106 107 1 108 96 0 107 108 1 109 97 0 108 109 1 109 106 1 110 91 1
		 111 93 1 110 111 1 112 92 0 111 112 1 113 90 1 112 113 1 113 110 1 114 110 1 115 111 1
		 114 115 1 116 112 1 115 116 1 117 113 1 116 117 1 117 114 1;
	setAttr -s 120 -ch 472 ".fc[0:119]" -type "polyFaces" 
		f 4 0 78 106 -22
		mu 0 4 0 48 68 69
		f 4 126 -23 -51 54
		mu 0 4 78 79 1 31
		f 4 1 80 -4 -24
		mu 0 4 2 50 51 4
		f 4 -25 2 56 -29
		mu 0 4 5 3 33 35
		f 3 26 -5 -26
		mu 0 3 4 7 6
		f 4 3 82 -6 -27
		mu 0 4 4 51 52 7
		f 3 28 -7 -28
		mu 0 3 5 9 8
		f 4 4 30 85 -30
		mu 0 4 6 7 53 55
		f 4 6 32 103 -32
		mu 0 4 8 9 65 67
		f 3 7 33 -11
		mu 0 3 10 11 14
		f 4 8 66 -12 -34
		mu 0 4 11 42 43 14
		f 3 9 35 -35
		mu 0 3 12 13 15
		f 4 11 68 -13 -37
		mu 0 4 14 43 44 16
		f 4 -38 -36 -56 -52
		mu 0 4 17 15 34 32
		f 4 116 115 -14 -114
		mu 0 4 73 74 45 18
		f 4 -15 -118 120 -54
		mu 0 4 30 19 75 76
		f 3 41 -16 -41
		mu 0 3 18 21 20
		f 4 13 72 -17 -42
		mu 0 4 18 45 46 21
		f 3 14 -18 -43
		mu 0 3 19 23 22
		f 4 91 90 -19 -89
		mu 0 4 58 59 25 24
		f 4 93 92 -20 -91
		mu 0 4 59 60 47 25
		f 4 97 96 -21 -95
		mu 0 4 61 62 27 26
		f 3 18 48 -48
		mu 0 3 24 25 28
		f 4 19 76 -1 -49
		mu 0 4 25 47 49 28
		f 3 20 50 -50
		mu 0 3 26 27 29
		f 4 -97 99 124 -55
		mu 0 4 31 63 77 78
		f 4 -99 101 -33 -57
		mu 0 4 33 64 66 35
		f 4 40 60 114 113
		mu 0 4 18 36 72 73
		f 4 88 61 110 109
		mu 0 4 57 37 70 71
		f 4 108 -62 47 21
		mu 0 4 69 70 37 0
		f 4 57 62 10 36
		mu 0 4 16 38 40 14
		f 4 86 63 29 87
		mu 0 4 56 39 41 54
		f 4 25 -64 59 23
		mu 0 4 4 41 39 2
		f 4 64 34 -66 -67
		mu 0 4 42 12 15 43
		f 4 -69 65 37 -68
		mu 0 4 44 43 15 17
		f 4 -116 118 117 -70
		mu 0 4 45 74 75 19
		f 4 -73 69 42 -72
		mu 0 4 46 45 19 22
		f 4 -93 95 94 -74
		mu 0 4 47 60 61 26
		f 4 -77 73 49 -76
		mu 0 4 49 47 26 29
		f 4 127 -79 75 22
		mu 0 4 79 68 48 1
		f 4 -81 77 24 -80
		mu 0 4 51 50 3 5
		f 4 -83 79 27 -82
		mu 0 4 52 51 5 8
		f 4 -86 83 -8 -85
		mu 0 4 55 53 11 10
		f 4 58 -88 84 -63
		mu 0 4 38 56 54 40
		f 4 43 -110 112 -61
		mu 0 4 36 57 71 72
		f 4 15 44 -92 -44
		mu 0 4 20 21 59 58
		f 4 16 74 -94 -45
		mu 0 4 21 46 60 59
		f 4 -96 -75 71 45
		mu 0 4 61 60 46 22
		f 4 17 46 -98 -46
		mu 0 4 22 23 62 61
		f 4 -100 -47 53 122
		mu 0 4 77 63 30 76
		f 4 -102 -53 55 -101
		mu 0 4 66 64 32 34
		f 4 -107 104 -2 -106
		mu 0 4 69 68 50 2
		f 4 -60 -108 -109 105
		mu 0 4 2 39 70 69
		f 4 -111 107 -87 89
		mu 0 4 71 70 39 56
		f 4 -113 -90 -59 -112
		mu 0 4 72 71 56 38
		f 4 111 -58 38 -115
		mu 0 4 72 38 16 73
		f 4 12 70 -117 -39
		mu 0 4 16 44 74 73
		f 4 -119 -71 67 39
		mu 0 4 75 74 44 17
		f 4 -40 51 -120 -121
		mu 0 4 75 17 32 76
		f 4 -122 -123 119 52
		mu 0 4 64 77 76 32
		f 4 -125 121 98 -124
		mu 0 4 78 77 64 33
		f 4 -3 -126 -127 123
		mu 0 4 33 3 79 78
		f 4 -105 -128 125 -78
		mu 0 4 50 68 79 3
		f 4 5 129 -131 -129
		mu 0 4 80 81 82 83
		f 4 -9 131 133 -133
		mu 0 4 84 85 86 87
		f 4 -31 128 135 -135
		mu 0 4 88 89 90 91
		f 4 31 137 -139 -137
		mu 0 4 92 93 94 95
		f 4 -65 132 140 -140
		mu 0 4 96 97 98 99
		f 4 81 136 -142 -130
		mu 0 4 100 101 102 103
		f 4 -84 134 142 -132
		mu 0 4 104 105 106 107
		f 4 102 139 -144 -138
		mu 0 4 108 109 110 111
		f 4 130 145 -147 -145
		mu 0 4 112 113 114 115
		f 4 -134 147 149 -149
		mu 0 4 116 117 118 119
		f 4 -136 144 151 -151
		mu 0 4 120 121 122 123
		f 4 138 153 -155 -153
		mu 0 4 124 125 126 127
		f 4 -141 148 156 -156
		mu 0 4 128 129 130 131
		f 4 141 152 -158 -146
		mu 0 4 132 133 134 135
		f 4 -143 150 158 -148
		mu 0 4 136 137 138 139
		f 4 143 155 -160 -154
		mu 0 4 140 141 142 143
		f 4 157 154 -162 -161
		mu 0 4 144 145 146 147
		f 4 -157 162 161 159
		mu 0 4 148 149 150 151
		f 4 146 160 -164 -152
		mu 0 4 152 153 154 155
		f 4 -150 -159 163 -163
		mu 0 4 156 157 158 159
		f 4 -104 164 203 -166
		mu 0 4 67 65 179 176
		f 4 -10 169 200 -168
		mu 0 4 13 12 177 178
		f 4 -103 165 198 -170
		mu 0 4 12 67 176 177
		f 4 167 202 -165 100
		mu 0 4 13 178 179 65
		f 4 -167 172 174 -174
		mu 0 4 160 161 165 164
		f 4 168 175 -177 -173
		mu 0 4 161 162 166 165
		f 4 -171 177 178 -176
		mu 0 4 162 163 167 166
		f 4 -172 173 179 -178
		mu 0 4 163 160 164 167
		f 4 -175 180 235 -182
		mu 0 4 164 165 207 204
		f 4 176 183 234 -181
		mu 0 4 165 166 206 207
		f 4 -179 185 232 -184
		mu 0 4 166 167 205 206
		f 4 -180 181 230 -186
		mu 0 4 167 164 204 205
		f 4 -191 188 171 -190
		mu 0 4 173 172 160 163
		f 4 -193 189 170 -192
		mu 0 4 174 173 163 162
		f 4 -195 191 -169 -194
		mu 0 4 175 174 162 161
		f 4 -196 193 166 -189
		mu 0 4 172 175 161 160
		f 4 -199 196 214 -198
		mu 0 4 177 176 196 197
		f 4 -201 197 216 -200
		mu 0 4 178 177 197 198
		f 4 -203 199 218 -202
		mu 0 4 179 178 198 199
		f 4 -204 201 219 -197
		mu 0 4 176 179 199 196
		f 4 -183 204 206 -206
		mu 0 4 180 181 182 183
		f 4 184 207 -209 -205
		mu 0 4 184 185 186 187
		f 4 -187 209 210 -208
		mu 0 4 188 189 190 191
		f 4 -188 205 211 -210
		mu 0 4 192 193 194 195
		f 4 -215 212 190 -214
		mu 0 4 197 196 172 173
		f 4 -217 213 192 -216
		mu 0 4 198 197 173 174
		f 4 -219 215 194 -218
		mu 0 4 199 198 174 175
		f 4 -220 217 195 -213
		mu 0 4 196 199 175 172
		f 4 -223 220 187 -222
		mu 0 4 201 200 168 171
		f 4 -225 221 186 -224
		mu 0 4 202 201 171 170
		f 4 -227 223 -185 -226
		mu 0 4 203 202 170 169
		f 4 -228 225 182 -221
		mu 0 4 200 203 169 168
		f 4 -231 228 222 -230
		mu 0 4 205 204 200 201
		f 4 -233 229 224 -232
		mu 0 4 206 205 201 202
		f 4 -235 231 226 -234
		mu 0 4 207 206 202 203
		f 4 -236 233 227 -229
		mu 0 4 204 207 203 200
		f 4 -212 -207 208 -211
		mu 0 4 208 209 210 211;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode lightLinker -s -n "lightLinker1";
	setAttr -s 3 ".lnk";
	setAttr -s 3 ".slnk";
createNode displayLayerManager -n "layerManager";
createNode displayLayer -n "defaultLayer";
createNode renderLayerManager -n "renderLayerManager";
createNode renderLayer -n "defaultRenderLayer";
	setAttr ".g" yes;
createNode script -n "uiConfigurationScriptNode";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"top\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n"
		+ "                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n                -rendererName \"base_OpenGL_Renderer\" \n"
		+ "                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n"
		+ "                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -shadows 0\n                $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n"
		+ "            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -maxConstantTransparency 1\n            -rendererName \"base_OpenGL_Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n"
		+ "            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n"
		+ "            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -shadows 0\n            $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"side\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n"
		+ "                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n                -rendererName \"base_OpenGL_Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n"
		+ "                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n"
		+ "                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -shadows 0\n                $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n"
		+ "            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -maxConstantTransparency 1\n            -rendererName \"base_OpenGL_Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n"
		+ "            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -dimensions 1\n"
		+ "            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -shadows 0\n            $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"front\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n"
		+ "                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n                -rendererName \"base_OpenGL_Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n"
		+ "                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n"
		+ "                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -shadows 0\n                $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n"
		+ "            -twoSidedLighting 1\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -maxConstantTransparency 1\n            -rendererName \"base_OpenGL_Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n"
		+ "            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n"
		+ "            -motionTrails 1\n            -clipGhosts 1\n            -shadows 0\n            $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n"
		+ "                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n                -rendererName \"base_OpenGL_Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n"
		+ "                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n"
		+ "                -locators 1\n                -manipulators 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -shadows 0\n                $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n"
		+ "            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -maxConstantTransparency 1\n            -rendererName \"base_OpenGL_Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n"
		+ "            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -shadows 0\n            $editorName;\n"
		+ "modelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `outlinerPanel -unParent -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            outlinerEditor -e \n                -showShapes 0\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 0\n                -showConnected 0\n                -showAnimCurvesOnly 0\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 1\n                -showAssets 1\n                -showContainedOnly 1\n                -showPublishedAsConnected 0\n                -showContainerContents 1\n                -ignoreDagHierarchy 0\n"
		+ "                -expandConnections 0\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 0\n                -highlightActive 1\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"defaultSetFilter\" \n                -showSetMembers 1\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n"
		+ "                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 0\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n"
		+ "            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n"
		+ "\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\tif ($useSceneConfig) {\n\t\toutlinerPanel -e -to $panelName;\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"graphEditor\" -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n"
		+ "                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n"
		+ "                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n"
		+ "                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n"
		+ "                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n"
		+ "                -showPinIcons 1\n                -mapMotionTrails 1\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                $editorName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dopeSheetPanel\" -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n"
		+ "                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n"
		+ "                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n"
		+ "                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n"
		+ "                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n"
		+ "                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"clipEditorPanel\" -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n"
		+ "                -manageSequencer 0 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"sequenceEditorPanel\" -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels `;\n"
		+ "\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 1 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n"
		+ "\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"hyperGraphPanel\" -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n"
		+ "                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showUnderworld 0\n                -showInvisible 0\n"
		+ "                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"hyperShadePanel\" -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"visorPanel\" -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"nodeEditorPanel\" -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n"
		+ "                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -ignoreAssets 1\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -island 0\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -syncedSelection 1\n                -extendToShapes 1\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -ignoreAssets 1\n                -additiveGraphingMode 0\n"
		+ "                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -island 0\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -syncedSelection 1\n                -extendToShapes 1\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"createNodePanel\" -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n"
		+ "\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Texture Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"polyTexturePlacementPanel\" -l (localizedPanelLabel(\"UV Texture Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Texture Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"renderWindowPanel\" -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n"
		+ "\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"blendShapePanel\" (localizedPanelLabel(\"Blend Shape\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\tblendShapePanel -unParent -l (localizedPanelLabel(\"Blend Shape\")) -mbv $menusOkayInPanels ;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tblendShapePanel -edit -l (localizedPanelLabel(\"Blend Shape\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dynRelEdPanel\" -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"relationshipPanel\" -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"referenceEditorPanel\" -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"componentEditorPanel\" -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dynPaintScriptedPanelType\" -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"scriptEditorPanel\" -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"Stereo\" (localizedPanelLabel(\"Stereo\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"Stereo\" -l (localizedPanelLabel(\"Stereo\")) -mbv $menusOkayInPanels `;\nstring $editorName = ($panelName+\"Editor\");\n            stereoCameraView -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n"
		+ "                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n"
		+ "                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 4 4 \n                -bumpResolution 4 4 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 0\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n"
		+ "                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -shadows 0\n                -displayMode \"centerEye\" \n                -viewColor 0 0 0 1 \n                $editorName;\nstereoCameraView -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Stereo\")) -mbv $menusOkayInPanels  $panelName;\nstring $editorName = ($panelName+\"Editor\");\n            stereoCameraView -e \n                -camera \"persp\" \n"
		+ "                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n"
		+ "                -maxConstantTransparency 1\n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 4 4 \n                -bumpResolution 4 4 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 0\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n"
		+ "                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -shadows 0\n                -displayMode \"centerEye\" \n                -viewColor 0 0 0 1 \n                $editorName;\nstereoCameraView -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n"
		+ "\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-defaultImage \"\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 1\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -maxConstantTransparency 1\\n    -rendererName \\\"base_OpenGL_Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -shadows 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 1\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -maxConstantTransparency 1\\n    -rendererName \\\"base_OpenGL_Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -shadows 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        setFocus `paneLayout -q -p1 $gMainPane`;\n        sceneUIReplacement -deleteRemaining;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 24 -ast 1 -aet 48 ";
	setAttr ".st" 6;
createNode polyCylinder -n "polyCylinder4";
	setAttr ".r" 0.30003358689141418;
	setAttr ".h" 0.4286927432493009;
	setAttr ".sa" 8;
	setAttr ".sh" 4;
	setAttr ".sc" 2;
	setAttr ".cuv" 3;
createNode polyDelEdge -n "polyDelEdge2";
	setAttr ".ics" -type "componentList" 1 "e[0:7]";
	setAttr ".cv" yes;
createNode polyTweak -n "polyTweak32";
	setAttr ".uopa" yes;
	setAttr -s 17 ".tk";
	setAttr ".tk[40]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[41]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[42]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[43]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[44]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[45]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[46]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[47]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[48]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[49]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[50]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[51]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[52]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[53]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[54]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[55]" -type "float3" 0 0.5026322 0 ;
	setAttr ".tk[57]" -type "float3" 0 0.5026322 0 ;
createNode polySplitRing -n "polySplitRing12";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[56:63]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".wt" 0.38421913981437683;
	setAttr ".re" 63;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak33";
	setAttr ".uopa" yes;
	setAttr -s 41 ".tk";
	setAttr ".tk[8]" -type "float3" 0 0.52210814 0 ;
	setAttr ".tk[9]" -type "float3" 0 0.52210814 0 ;
	setAttr ".tk[10]" -type "float3" 0 0.52210814 0 ;
	setAttr ".tk[11]" -type "float3" 0 0.52210814 0 ;
	setAttr ".tk[12]" -type "float3" 0 0.52210814 0 ;
	setAttr ".tk[13]" -type "float3" 0 0.52210814 0 ;
	setAttr ".tk[14]" -type "float3" 0 0.52210814 0 ;
	setAttr ".tk[15]" -type "float3" 0 0.52210814 0 ;
	setAttr ".tk[16]" -type "float3" -0.074100748 0.57146978 0.07410077 ;
	setAttr ".tk[17]" -type "float3" 5.2046056e-009 0.57146978 0.10479429 ;
	setAttr ".tk[18]" -type "float3" 0.074100778 0.57146978 0.07410077 ;
	setAttr ".tk[19]" -type "float3" 0.10479429 0.57146978 0 ;
	setAttr ".tk[20]" -type "float3" 0.074100778 0.57146978 -0.07410077 ;
	setAttr ".tk[21]" -type "float3" 5.2046056e-009 0.57146978 -0.10479429 ;
	setAttr ".tk[22]" -type "float3" -0.074100733 0.57146978 -0.074100778 ;
	setAttr ".tk[23]" -type "float3" -0.10479429 0.57146978 0 ;
	setAttr ".tk[24]" -type "float3" -0.054864567 0.49886891 0.054864567 ;
	setAttr ".tk[25]" -type "float3" 3.8535202e-009 0.49886891 0.077590242 ;
	setAttr ".tk[26]" -type "float3" 0.05486457 0.49886891 0.054864567 ;
	setAttr ".tk[27]" -type "float3" 0.07759016 0.49886891 0 ;
	setAttr ".tk[28]" -type "float3" 0.05486457 0.49886891 -0.054864567 ;
	setAttr ".tk[29]" -type "float3" 3.8535202e-009 0.49886891 -0.077590242 ;
	setAttr ".tk[30]" -type "float3" -0.054864582 0.49886891 -0.05486457 ;
	setAttr ".tk[31]" -type "float3" -0.07759016 0.49886891 0 ;
	setAttr ".tk[32]" -type "float3" -0.054864567 -0.025664339 0.054864567 ;
	setAttr ".tk[33]" -type "float3" 3.8535202e-009 -0.025664339 0.077590242 ;
	setAttr ".tk[34]" -type "float3" 0.05486457 -0.025664339 0.054864567 ;
	setAttr ".tk[35]" -type "float3" 0.07759016 -0.025664339 0 ;
	setAttr ".tk[36]" -type "float3" 0.05486457 -0.025664339 -0.054864567 ;
	setAttr ".tk[37]" -type "float3" 3.8535202e-009 -0.025664339 -0.077590242 ;
	setAttr ".tk[38]" -type "float3" -0.054864582 -0.025664339 -0.05486457 ;
	setAttr ".tk[39]" -type "float3" -0.07759016 -0.025664339 0 ;
	setAttr ".tk[40]" -type "float3" 0.03819317 -0.025664339 -0.038193185 ;
	setAttr ".tk[41]" -type "float3" -7.5581175e-010 -0.025664339 -0.054013327 ;
	setAttr ".tk[42]" -type "float3" -0.03819317 -0.025664339 -0.038193185 ;
	setAttr ".tk[43]" -type "float3" -0.054013327 -0.025664339 0 ;
	setAttr ".tk[44]" -type "float3" -0.03819317 -0.025664339 0.038193185 ;
	setAttr ".tk[45]" -type "float3" -7.5581175e-010 -0.025664339 0.054013327 ;
	setAttr ".tk[46]" -type "float3" 0.03819317 -0.025664339 0.038193185 ;
	setAttr ".tk[47]" -type "float3" 0.054013342 -0.025664339 0 ;
	setAttr ".tk[49]" -type "float3" 3.8535202e-009 -0.025664339 0 ;
createNode polyTweak -n "polyTweak34";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[50:57]" -type "float3"  0.010718024 0 0 0.0075787897
		 0 0.0075787897 -5.3231053e-010 0 0.010718024 -0.0075787879 0 0.0075787874 -0.010718024
		 0 0 -0.0075787879 0 -0.0075787874 -5.3231053e-010 0 -0.010718024 0.0075787874 0 -0.0075787874;
createNode deleteComponent -n "deleteComponent13";
	setAttr ".dc" -type "componentList" 1 "f[0:7]";
createNode polyExtrudeEdge -n "polyExtrudeEdge7";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[0:7]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 6.7673774 0.23840784 3.5438788 ;
	setAttr ".rs" 35854;
	setAttr ".kft" no;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 6.4673437831162595 0.23840784284848163 3.2438452480118234 ;
	setAttr ".cbx" -type "double3" 7.0674109515904568 0.23840784284848163 3.8439123866836984 ;
createNode polyTweak -n "polyTweak35";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[0:7]" -type "float3"  0 0.23840785 0 0 0.23840785
		 0 0 0.23840785 0 0 0.23840785 0 0 0.23840785 0 0 0.23840785 0 0 0.23840785 0 0 0.23840785
		 0;
createNode polyExtrudeEdge -n "polyExtrudeEdge8";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 8 "e[114]" "e[117]" "e[120]" "e[123]" "e[126]" "e[129]" "e[132]" "e[135]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 6.7673774 0.16531172 3.5438788 ;
	setAttr ".rs" 32929;
	setAttr ".kft" no;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 6.5114485380410336 0.16531172398108432 3.2879500029365976 ;
	setAttr ".cbx" -type "double3" 7.0233061668633603 0.16531172398108432 3.7998076317589242 ;
createNode polyTweak -n "polyTweak36";
	setAttr ".uopa" yes;
	setAttr -s 16 ".tk[57:72]" -type "float3"  -0.0311868 -0.073096119 0.0311868
		 0 -0.073096119 0.044104766 0 -0.073096119 0.044104766 0.0311868 -0.073096119 0.0311868
		 0.0311868 -0.073096119 0.0311868 0.044104766 -0.073096119 0 0.044104766 -0.073096119
		 0 0.0311868 -0.073096119 -0.0311868 0.0311868 -0.073096119 -0.0311868 0 -0.073096119
		 -0.044104766 0 -0.073096119 -0.044104766 -0.0311868 -0.073096119 -0.0311868 -0.0311868
		 -0.073096119 -0.0311868 -0.044104766 -0.073096119 0 -0.044104766 -0.073096119 0 -0.0311868
		 -0.073096119 0.0311868;
createNode polyMergeVert -n "polyMergeVert52";
	setAttr ".ics" -type "componentList" 1 "vtx[84:85]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyTweak -n "polyTweak37";
	setAttr ".uopa" yes;
	setAttr -s 16 ".tk[73:88]" -type "float3"  -0.030222952 -0.032313287
		 0.030222921 0 -0.032313287 0.042741645 0 -0.032313287 0.042741645 0.030222952 -0.032313287
		 0.030222921 0.030222952 -0.032313287 0.030222921 0.042741768 -0.032313287 0 0.042741768
		 -0.032313287 0 0.030222952 -0.032313287 -0.030222921 0.030222952 -0.032313287 -0.030222921
		 0 -0.032313287 -0.042741645 0 -0.032313287 -0.042741645 -0.030222952 -0.032313287
		 -0.030222921 -0.030222952 -0.032313287 -0.030222921 -0.042741768 -0.032313287 0 -0.042741768
		 -0.032313287 0 -0.030222952 -0.032313287 0.030222921;
createNode polyMergeVert -n "polyMergeVert53";
	setAttr ".ics" -type "componentList" 1 "vtx[82:83]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert54";
	setAttr ".ics" -type "componentList" 1 "vtx[80:81]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert55";
	setAttr ".ics" -type "componentList" 1 "vtx[78:79]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert56";
	setAttr ".ics" -type "componentList" 1 "vtx[76:77]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert57";
	setAttr ".ics" -type "componentList" 1 "vtx[74:75]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert58";
	setAttr ".ics" -type "componentList" 2 "vtx[73]" "vtx[82]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert59";
	setAttr ".ics" -type "componentList" 1 "vtx[80:81]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert60";
	setAttr ".ics" -type "componentList" 1 "vtx[66:67]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert61";
	setAttr ".ics" -type "componentList" 1 "vtx[67:68]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert62";
	setAttr ".ics" -type "componentList" 1 "vtx[68:69]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert63";
	setAttr ".ics" -type "componentList" 2 "vtx[57]" "vtx[69]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert64";
	setAttr ".ics" -type "componentList" 1 "vtx[58:59]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert65";
	setAttr ".ics" -type "componentList" 1 "vtx[59:60]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert66";
	setAttr ".ics" -type "componentList" 1 "vtx[60:61]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert67";
	setAttr ".ics" -type "componentList" 1 "vtx[61:62]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyExtrudeEdge -n "polyExtrudeEdge9";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 7 "e[130]" "e[132]" "e[134]" "e[136]" "e[138]" "e[140]" "e[142:143]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 6.7673774 0.13299844 3.5438788 ;
	setAttr ".rs" 44427;
	setAttr ".kft" no;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 6.5541901347397946 0.13299842927235553 3.3306917039434869 ;
	setAttr ".cbx" -type "double3" 6.9805645701645993 0.13299842927235553 3.7570659307520353 ;
createNode polyMergeVert -n "polyMergeVert68";
	setAttr ".ics" -type "componentList" 1 "vtx[82:83]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyTweak -n "polyTweak38";
	setAttr ".uopa" yes;
	setAttr -s 16 ".tk[73:88]" -type "float3"  -0.077040523 0 0.077040419
		 0 0 0.10895162 0 0 0.10895162 0.077040523 0 0.077040419 0.077040523 0 0.077040419
		 0.10895162 0 0 0.10895162 0 0 0.077040523 0 -0.077040419 0.077040523 0 -0.077040419
		 0 0 -0.10895162 0 0 -0.10895162 -0.077040523 0 -0.077040419 -0.077040523 0 -0.077040419
		 -0.10895162 0 0 -0.10895162 0 0 -0.077040523 0 0.077040419;
createNode polyMergeVert -n "polyMergeVert69";
	setAttr ".ics" -type "componentList" 1 "vtx[83:84]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert70";
	setAttr ".ics" -type "componentList" 1 "vtx[84:85]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert71";
	setAttr ".ics" -type "componentList" 2 "vtx[73]" "vtx[85]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert72";
	setAttr ".ics" -type "componentList" 1 "vtx[74:75]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert73";
	setAttr ".ics" -type "componentList" 1 "vtx[75:76]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert74";
	setAttr ".ics" -type "componentList" 1 "vtx[76:77]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert75";
	setAttr ".ics" -type "componentList" 1 "vtx[77:78]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert76";
	setAttr ".ics" -type "componentList" 1 "vtx[73:80]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 6.767377352452197 0.21434637162465045 3.5438788173477609 1;
createNode polyTweak -n "polyTweak39";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[73:80]" -type "float3"  -0.073705822 0 0.073705688
		 1.7763568e-015 0 0.1042356 0.073705822 0 0.073705688 0.1042356 0 0 0.073705822 0
		 -0.073705688 1.7763568e-015 0 -0.1042356 -0.073705822 0 -0.073705688 -0.1042356 0
		 0;
createNode deleteComponent -n "deleteComponent14";
	setAttr ".dc" -type "componentList" 1 "f[40:47]";
createNode groupId -n "groupId1";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts1";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:71]";
createNode groupId -n "groupId2";
	setAttr ".ihi" 0;
createNode groupId -n "groupId3";
	setAttr ".ihi" 0;
createNode groupId -n "groupId4";
	setAttr ".ihi" 0;
createNode shadingEngine -n "hands:initialShadingGroup";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "hands:materialInfo1";
createNode lambert -n "hands:initialShadingGroup1";
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :renderPartition;
	setAttr -s 3 ".st";
select -ne :initialShadingGroup;
	setAttr -s 5 ".dsm";
	setAttr ".ro" yes;
	setAttr -s 4 ".gn";
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultShaderList1;
	setAttr -s 3 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :renderGlobalsList1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :defaultHardwareRenderGlobals;
	setAttr ".fn" -type "string" "im";
	setAttr ".res" -type "string" "ntsc_4d 646 485 1.333";
connectAttr "groupId1.id" "pCylinderShape1.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCylinderShape1.iog.og[0].gco";
connectAttr "groupParts1.og" "pCylinderShape1.i";
connectAttr "groupId2.id" "pCylinderShape1.ciog.cog[0].cgid";
connectAttr "groupId3.id" "pCylinderShape2.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCylinderShape2.iog.og[0].gco";
connectAttr "groupId4.id" "pCylinderShape2.ciog.cog[0].cgid";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "hands:initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "hands:initialShadingGroup.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "polyTweak32.out" "polyDelEdge2.ip";
connectAttr "polyCylinder4.out" "polyTweak32.ip";
connectAttr "polyTweak33.out" "polySplitRing12.ip";
connectAttr "pCylinderShape1.wm" "polySplitRing12.mp";
connectAttr "polyDelEdge2.out" "polyTweak33.ip";
connectAttr "polySplitRing12.out" "polyTweak34.ip";
connectAttr "polyTweak34.out" "deleteComponent13.ig";
connectAttr "polyTweak35.out" "polyExtrudeEdge7.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeEdge7.mp";
connectAttr "deleteComponent13.og" "polyTweak35.ip";
connectAttr "polyTweak36.out" "polyExtrudeEdge8.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeEdge8.mp";
connectAttr "polyExtrudeEdge7.out" "polyTweak36.ip";
connectAttr "polyTweak37.out" "polyMergeVert52.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert52.mp";
connectAttr "polyExtrudeEdge8.out" "polyTweak37.ip";
connectAttr "polyMergeVert52.out" "polyMergeVert53.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert53.mp";
connectAttr "polyMergeVert53.out" "polyMergeVert54.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert54.mp";
connectAttr "polyMergeVert54.out" "polyMergeVert55.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert55.mp";
connectAttr "polyMergeVert55.out" "polyMergeVert56.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert56.mp";
connectAttr "polyMergeVert56.out" "polyMergeVert57.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert57.mp";
connectAttr "polyMergeVert57.out" "polyMergeVert58.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert58.mp";
connectAttr "polyMergeVert58.out" "polyMergeVert59.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert59.mp";
connectAttr "polyMergeVert59.out" "polyMergeVert60.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert60.mp";
connectAttr "polyMergeVert60.out" "polyMergeVert61.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert61.mp";
connectAttr "polyMergeVert61.out" "polyMergeVert62.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert62.mp";
connectAttr "polyMergeVert62.out" "polyMergeVert63.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert63.mp";
connectAttr "polyMergeVert63.out" "polyMergeVert64.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert64.mp";
connectAttr "polyMergeVert64.out" "polyMergeVert65.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert65.mp";
connectAttr "polyMergeVert65.out" "polyMergeVert66.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert66.mp";
connectAttr "polyMergeVert66.out" "polyMergeVert67.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert67.mp";
connectAttr "polyMergeVert67.out" "polyExtrudeEdge9.ip";
connectAttr "pCylinderShape1.wm" "polyExtrudeEdge9.mp";
connectAttr "polyTweak38.out" "polyMergeVert68.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert68.mp";
connectAttr "polyExtrudeEdge9.out" "polyTweak38.ip";
connectAttr "polyMergeVert68.out" "polyMergeVert69.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert69.mp";
connectAttr "polyMergeVert69.out" "polyMergeVert70.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert70.mp";
connectAttr "polyMergeVert70.out" "polyMergeVert71.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert71.mp";
connectAttr "polyMergeVert71.out" "polyMergeVert72.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert72.mp";
connectAttr "polyMergeVert72.out" "polyMergeVert73.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert73.mp";
connectAttr "polyMergeVert73.out" "polyMergeVert74.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert74.mp";
connectAttr "polyMergeVert74.out" "polyMergeVert75.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert75.mp";
connectAttr "polyTweak39.out" "polyMergeVert76.ip";
connectAttr "pCylinderShape1.wm" "polyMergeVert76.mp";
connectAttr "polyMergeVert75.out" "polyTweak39.ip";
connectAttr "polyMergeVert76.out" "deleteComponent14.ig";
connectAttr "deleteComponent14.og" "groupParts1.ig";
connectAttr "groupId1.id" "groupParts1.gi";
connectAttr "hands:initialShadingGroup1.oc" "hands:initialShadingGroup.ss";
connectAttr "hands:initialShadingGroup.msg" "hands:materialInfo1.sg";
connectAttr "hands:initialShadingGroup1.msg" "hands:materialInfo1.m";
connectAttr "hands:initialShadingGroup.pa" ":renderPartition.st" -na;
connectAttr "pCylinderShape1.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCylinderShape1.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCylinderShape2.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCylinderShape2.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "soupladle_mesh_001Shape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "groupId1.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId2.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId3.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId4.msg" ":initialShadingGroup.gn" -na;
connectAttr "hands:initialShadingGroup1.msg" ":defaultShaderList1.s" -na;
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
// End of soupladle_mesh_001.ma
