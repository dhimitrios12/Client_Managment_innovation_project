import 'package:clientManagmentMobile/screens/auth_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:provider/provider.dart';

import './screens/auth_screen.dart';
import './screens/tabs_screen.dart';
import './providers/auth_provider.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    SystemChrome.setPreferredOrientations([DeviceOrientation.portraitUp]);
    return ChangeNotifierProvider.value(
      value: Auth(),
      child: Consumer<Auth>(
        builder: (context, authObject, _) => MaterialApp(
          title: 'Flutter Demo',
          theme: ThemeData(
            primarySwatch: Colors.blue,
            accentColor: Colors.red,
            visualDensity: VisualDensity.adaptivePlatformDensity,
            textTheme: ThemeData.light().textTheme.copyWith(
                  headline6: TextStyle(
                    fontFamily: 'Raleway',
                    fontSize: 17,
                  ),
                  button: TextStyle(
                    fontFamily: 'Raleway',
                    fontSize: 15,
                    color: Colors.white,
                  ),
                ),
            appBarTheme: ThemeData.light().appBarTheme.copyWith(
                  textTheme: ThemeData.light().textTheme.copyWith(
                        headline6: TextStyle(
                          fontFamily: 'Raleway',
                          fontSize: 20,
                        ),
                      ),
                ),
          ),
          home: authObject.isAthenticated == true
              ? TabsScreen()
              : AuthenticationScreen(),
        ),
      ),
    );
  }
}
