import 'package:flutter/material.dart';

class MonthColor {
  static Color getMonthColor(int month) {
    switch (month) {
      case 1:
        return Colors.red;
        break;
      case 2:
        return Colors.teal;
        break;
      case 3:
        return Colors.amber[700];
        break;
      case 4:
        return Colors.blue;
        break;
      case 5:
        return Colors.brown[300];
        break;
      case 6:
        return Colors.deepOrange[400];
        break;
      case 7:
        return Colors.deepPurple;
        break;
      case 8:
        return Colors.green;
        break;
      case 9:
        return Colors.grey;
        break;
      case 10:
        return Colors.indigo;
        break;
      case 11:
        return Colors.lightBlue;
        break;
      case 12:
        return Colors.lime;
        break;
      default:
        return Colors.deepOrange;
    }
  }
}
