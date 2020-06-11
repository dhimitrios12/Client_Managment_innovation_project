import 'package:flutter/material.dart';

enum AuthMode { Login, Register }

class AutharisationPanel extends StatefulWidget {
  @override
  _AutharisationPanelState createState() => _AutharisationPanelState();
}

class _AutharisationPanelState extends State<AutharisationPanel> {
  AuthMode _authMode = AuthMode.Login;

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
          child: SingleChildScrollView(
            child: Column(
              children: <Widget>[
                TextFormField(
                  decoration: InputDecoration(labelText: 'E-mail'),
                ),
                TextFormField(
                  decoration: InputDecoration(labelText: 'Password'),
                ),
                if (_authMode == AuthMode.Register)
                  TextFormField(
                    decoration: InputDecoration(labelText: 'Confirm password'),
                  ),
                SizedBox(
                  height: 20,
                ),
                RaisedButton(
                  onPressed: () {},
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
