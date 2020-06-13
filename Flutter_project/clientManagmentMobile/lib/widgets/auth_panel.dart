import 'dart:convert';

import 'package:clientManagmentMobile/models/api_common_exception.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:dio/dio.dart';

import '../providers/auth_provider.dart';

enum AuthMode { Login, Register }

class AutharisationPanel extends StatefulWidget {
  @override
  _AutharisationPanelState createState() => _AutharisationPanelState();
}

class _AutharisationPanelState extends State<AutharisationPanel> {
  AuthMode _authMode = AuthMode.Login;
  // Focus nodes should be disposed
  final _passwordFocusNode = FocusNode();
  final _confirmPasswordFocusNode = FocusNode();
  final _surnameFocusNode = FocusNode();
  final _emailFocusNode = FocusNode();
  // Global key - used to interact with a widget.
  // Ususaly used woth forms to access their FormState
  final _loginForm = GlobalKey<FormState>();
  final _passwordController = TextEditingController();
  var _isLoading = false;

  // Inputed data
  String _name;
  String _surname;
  String _email;
  String _password;

  void _switchAuthMode() {
    if (_authMode == AuthMode.Login) {
      setState(() {
        _authMode = AuthMode.Register;
      });
    } else {
      setState(() {
        _authMode = AuthMode.Login;
      });
    }
  }

  void _showErrorDialog(String errorMessage) {
    showDialog(
        context: context,
        builder: (ctx) => AlertDialog(
              title: Text('Gabim'),
              content: Text(errorMessage),
              actions: <Widget>[
                FlatButton(
                  onPressed: () => Navigator.of(ctx).pop(),
                  child: Text('Ne rregull'),
                ),
              ],
            ));
  }

  Future<void> _saveForm() async {
    // Validate form data
    if (!_loginForm.currentState.validate()) {
      return;
    }
    // Saves the state of the Form widget and allows to take the values stored inside TextFormFields imputs
    // It executes OnSaved funstion in each input
    _loginForm.currentState.save();

    setState(() {
      _isLoading = true;
    });
    try {
      if (_authMode == AuthMode.Login) {
        // Login
        await Provider.of<Auth>(context, listen: false)
            .login(_email, _password);
      } else {
        // Register
        await Provider.of<Auth>(context, listen: false)
            .register(_name, _surname, _email, _password);
      }
    } on DioError catch (error) {
      print(error.message);
      print(error.response.data);
      var b = error.response.data;
      //var a = jsonDecode(b);
      CommonException exceptionData = CommonException.fromJOSN(b);
      String errorMessage = 'Procesi deshtoi. Provoni perseri me vone!';
      if (exceptionData.field.toLowerCase() == 'email') {
        if (_authMode == AuthMode.Register) {
          errorMessage = 'Ekziston nje perdorues i rregjistruar me kete email.';
        } else {
          errorMessage = 'Email i gabuar.';
        }
      } else if (exceptionData.field.toLowerCase() == 'password') {
        errorMessage = 'Password i gabuar.';
      }

      _showErrorDialog(errorMessage);
    } catch (ex) {
      const errorMessage = 'Procesi deshtoi. Provoni perseri me vone!';
      _showErrorDialog(errorMessage);
    }

    setState(() {
      _isLoading = false;
    });
  }

  @override
  void dispose() {
    _passwordFocusNode.dispose();
    _confirmPasswordFocusNode.dispose();
    _surnameFocusNode.dispose();
    _emailFocusNode.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final deviceSize = MediaQuery.of(context).size;
    return Card(
      elevation: 8,
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(15),
      ),
      child: Container(
        width: deviceSize.width * 0.75,
        padding: EdgeInsets.all(20),
        child: Form(
          key: _loginForm,
          child: SingleChildScrollView(
            child: Column(
              children: <Widget>[
                if (_authMode == AuthMode.Register)
                  TextFormField(
                    key: ValueKey('nameKey'),
                    decoration: InputDecoration(labelText: 'Emri'),
                    enabled: _authMode == AuthMode.Login ? false : true,
                    textInputAction: TextInputAction.next,
                    onFieldSubmitted: (_) {
                      FocusScope.of(context).requestFocus(_surnameFocusNode);
                    },
                    validator: (value) {
                      Pattern namePattern = r'^([A-Z][A-Za-z-]+)$';
                      RegExp regex = RegExp(namePattern);
                      if (value.isNotEmpty && regex.hasMatch(value)) {
                        return null;
                      }
                      return 'Emri nuk eshte i pranueshem';
                    },
                    onSaved: (value) {
                      _name = value;
                    },
                  ),
                if (_authMode == AuthMode.Register)
                  TextFormField(
                    key: ValueKey('surnameKey'),
                    enabled: _authMode == AuthMode.Login ? false : true,
                    decoration: InputDecoration(labelText: 'Mbiemri'),
                    textInputAction: TextInputAction.next,
                    focusNode: _surnameFocusNode,
                    onFieldSubmitted: (_) {
                      FocusScope.of(context).requestFocus(_emailFocusNode);
                    },
                    validator: (value) {
                      Pattern surnamePattern = r'^([A-Z][A-Za-z-]+)$';
                      RegExp regex = RegExp(surnamePattern);
                      if (value.isNotEmpty && regex.hasMatch(value)) {
                        return null;
                      }
                      return 'Mbiemri nuk eshte i pranueshem';
                    },
                    onSaved: (value) {
                      _surname = value;
                    },
                  ),
                TextFormField(
                  key: ValueKey('emailKey'),
                  decoration: InputDecoration(labelText: 'E-mail'),
                  textInputAction: TextInputAction.next,
                  keyboardType: TextInputType.emailAddress,
                  focusNode: _emailFocusNode,
                  onFieldSubmitted: (_) {
                    FocusScope.of(context).requestFocus(_passwordFocusNode);
                  },
                  validator: (value) {
                    Pattern emailPattern =
                        r'^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$';
                    RegExp regex = RegExp(emailPattern);
                    if (value.isNotEmpty && regex.hasMatch(value)) {
                      return null;
                    }
                    return 'Email nuk eshte ne formatin e duhur';
                  },
                  onSaved: (value) {
                    _email = value;
                  },
                ),
                TextFormField(
                  key: ValueKey('passwordKey'),
                  decoration: InputDecoration(
                    labelText: 'Password',
                  ),
                  textInputAction: _authMode == AuthMode.Login
                      ? TextInputAction.done
                      : TextInputAction.next,
                  keyboardType: TextInputType.visiblePassword,
                  controller: _passwordController,
                  obscureText: true,
                  focusNode: _passwordFocusNode,
                  onFieldSubmitted: (_) {
                    FocusScope.of(context)
                        .requestFocus(_confirmPasswordFocusNode);
                  },
                  validator: (value) {
                    if (value.length < 6) {
                      return 'Password duhet te kete minimumi 6 karaktere';
                    }
                    Pattern passwordPattern =
                        r'^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*)[A-Za-z\d]{6,}$';
                    RegExp regex = RegExp(passwordPattern);
                    if (value.isNotEmpty && regex.hasMatch(value)) {
                      return null;
                    }
                    return 'Kerkohet shkronje e madhe, e vogel dhe numer';
                  },
                  onSaved: (value) {
                    _password = value;
                  },
                ),
                if (_authMode == AuthMode.Register)
                  TextFormField(
                    enabled: _authMode == AuthMode.Login ? false : true,
                    decoration: InputDecoration(labelText: 'Konfirmo password'),
                    obscureText: true,
                    textInputAction: TextInputAction.done,
                    keyboardType: TextInputType.visiblePassword,
                    focusNode: _confirmPasswordFocusNode,
                    onFieldSubmitted: (_) {
                      FocusScope.of(context).unfocus();
                    },
                    validator: (value) {
                      final password = _passwordController.text;
                      if (value != password) {
                        //return 'Passowrd nuk perputhet';
                      }
                      return null;
                    },
                  ),
                SizedBox(
                  height: 20,
                ),
                if (_isLoading == true)
                  CircularProgressIndicator()
                else
                  RaisedButton(
                    onPressed: _saveForm,
                    color: Theme.of(context).primaryColor,
                    child: Text(
                      _authMode == AuthMode.Login ? 'Hyr' : 'Regjistrohu',
                      style: TextStyle(
                        color: Colors.white,
                        fontFamily: 'Raleway',
                        fontWeight: FontWeight.bold,
                        fontSize: 17,
                      ),
                    ),
                  ),
                FlatButton(
                  onPressed: _switchAuthMode,
                  child: Text(
                    _authMode == AuthMode.Login ? 'Regjistrohu' : 'Hyr',
                    style: TextStyle(
                      color: Colors.grey[700],
                      fontFamily: 'Raleway',
                      fontSize: 13,
                    ),
                  ),
                  materialTapTargetSize: MaterialTapTargetSize.shrinkWrap,
                )
              ],
            ),
          ),
        ),
      ),
    );
  }
}
