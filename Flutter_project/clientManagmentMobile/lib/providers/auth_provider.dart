import 'package:flutter/widgets.dart';
import 'package:dio/dio.dart';

import '../models/user_auth_response.dart';

class Auth with ChangeNotifier {
  String _name;
  String _surname;
  String _email;
  String _token;
  DateTime _expiryDate; // For token
  String _userId;

  bool get isAthenticated {
    return token != null;
  }

  String get token {
    if (_token != null &&
        _expiryDate != null &&
        _expiryDate.isAfter(DateTime.now())) {
      return _token;
    }
    return null;
  }

  Future<void> login(String email, String password) async {
    const String url = 'http://192.168.1.239:8080/api/Authentication/Token';

    try {
      final Response response = await Dio().post(
        url,
        data: {
          "email": email,
          "password": password,
        },
      );
      // Add user data to state
      _addUserDatatoState(response);
      notifyListeners();
    } on DioError catch (error) {
      throw error;
    } catch (ex) {
      throw ex;
    }
  }

  Future<void> register(
      String name, String surname, String email, String password) async {
    const String url = 'http://192.168.1.239:8080/api/Authentication/Register';
    try {
      final Response response = await Dio().post(
        url,
        data: {
          "name": name,
          "surname": surname,
          "email": email,
          "password": password,
        },
      );
      // Add user data to state
      _addUserDatatoState(response);
      notifyListeners();
    } on DioError catch (error) {
      throw error;
    } catch (ex) {
      throw ex;
    }
  }

  void _addUserDatatoState(Response response) {
    if (response.statusCode == 200) {
      final UserAuthResponse userData =
          UserAuthResponse.fromJson(response.data);
      _name = userData.name;
      _surname = userData.surname;
      _userId = userData.userId;
      _email = userData.email;
      _token = userData.token;
      _expiryDate = DateTime.parse(userData.tokenExpirationDate);
    }
  }
}
