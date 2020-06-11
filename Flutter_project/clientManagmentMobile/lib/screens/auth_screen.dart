import 'dart:math';

import 'package:flutter/material.dart';

import '../widgets/auth_panel.dart';

class AuthenticationScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final deviceSize = MediaQuery.of(context).size;
    return Scaffold(
      body: Stack(
        children: <Widget>[
          Container(
            alignment: Alignment.center,
            decoration: BoxDecoration(
              image: DecorationImage(
                image: AssetImage('assets/images/time_is_money.jpg'),
                fit: BoxFit.cover,
                colorFilter: ColorFilter.mode(
                  Colors.grey[900],
                  BlendMode.overlay,
                ),
              ),
            ),
          ),
          SingleChildScrollView(
            child: Container(
              height: deviceSize.height,
              width: deviceSize.width,
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                crossAxisAlignment: CrossAxisAlignment.center,
                children: <Widget>[
                  Flexible(
                    child: Container(
                      transform: Matrix4.rotationZ(-8 * pi / 200)
                        ..translate(-10.0),
                      padding: EdgeInsets.all(10),
                      margin: EdgeInsets.all(25),
                      decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(10),
                          boxShadow: [
                            BoxShadow(
                              color: Colors.grey[800],
                              blurRadius: 5,
                              offset: Offset(4, 4),
                            )
                          ],
                          color: Colors.orangeAccent[400]),
                      child: Text(
                        'Kape radhen!',
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 35,
                        ),
                      ),
                    ),
                  ),
                  Flexible(
                      flex: deviceSize.height > 600 ? 2 : 1,
                      child: AutharisationPanel()),
                ],
              ),
            ),
          )
        ],
      ),
    );
  }
}
