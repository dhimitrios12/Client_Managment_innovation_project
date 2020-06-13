import 'package:flutter/widgets.dart';
import 'package:dio/dio.dart';

import '../models/user_auth_response.dart';
import '../models/helpers/custom_dio_client.dart';

enum Role { Businessman, Customer, Administrator }

class Auth with ChangeNotifier {
  String _name;
  String _surname;
  String _email;
  List<Role> _roles;
  String _token;
  DateTime _expiryDate; // For token
  String _userId;

  CustomDioClient dio = CustomDioClient(Dio());

  bool get isAthenticated {
    return token != null;
  }

  bool hasRole(Role role) {
    bool a = _roles.contains(role);
    return a;
  }

  String get token {
    if (_token != null &&
        _expiryDate != null &&
        _expiryDate.isAfter(DateTime.now())) {
      return _token;
    }
    return null;
  }

  void _mapUserRoles(List<String> roles) {
    if (_roles != null && _roles.length > 0) {
      _roles.clear();
    } else {
      _roles = List<Role>();
    }
    roles.forEach((role) {
      switch (role.toLowerCase()) {
        case 'businessman':
          _roles.add(Role.Businessman);
          break;
        case 'administrator':
          _roles.add(Role.Administrator);
          break;
        default:
          _roles.add(Role.Customer);
      }
    });
  }

  Future<void> login(String email, String password) async {
    const String url = '/Authentication/Token';

    try {
      final Response response = await dio.client.post(
        url,
        data: {
          "email": email,
          "password": password,
        },
      );
      // Add user data to state
      _addUserDataToState(response);
      notifyListeners();
    } on DioError catch (error) {
      throw error;
    } catch (ex) {
      throw ex;
    }
  }

  Future<void> register(
      String name, String surname, String email, String password) async {
    const String url = '/Authentication/Register';
    try {
      final Response response = await dio.client.post(
        url,
        data: {
          "name": name,
          "surname": surname,
          "email": email,
          "password": password,
        },
      );
      // Add user data to state
      _addUserDataToState(response);
      notifyListeners();
    } on DioError catch (error) {
      throw error;
    } catch (ex) {
      throw ex;
    }
  }

  void _addUserDataToState(Response response) {
    if (response.statusCode == 200) {
      final UserAuthResponse userData =
          UserAuthResponse.fromJson(response.data);
      _name = userData.name;
      _surname = userData.surname;
      _userId = userData.userId;
      _email = userData.email;
      _mapUserRoles(userData.roles);
      _token = userData.token;
      _expiryDate = DateTime.parse(userData.tokenExpirationDate);
    }
  }
}
