import 'package:clientManagmentMobile/providers/business_events_provider.dart';
import 'package:clientManagmentMobile/screens/auth_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:intl/date_symbol_data_local.dart';
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
    initializeDateFormatting('sq');
    SystemChrome.setPreferredOrientations([DeviceOrientation.portraitUp]);
    return MultiProvider(
      providers: [
        ChangeNotifierProvider(
          create: (ctx) => Auth(),
        ),
        ChangeNotifierProvider(
          create: (ctx) => BusinessEvents(),
        ),
      ],
      child: Consumer<Auth>(
        builder: (context, authObject, _) => MaterialApp(
          title: 'Flutter Demo',
          theme: ThemeData(
            primarySwatch: Colors.blue,
            accentColor: Colors.deepOrange,
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
