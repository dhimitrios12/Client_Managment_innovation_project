import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import './upcoming_events_screent.dart';
import './randomSecondTab.dart';
import '../providers/auth_provider.dart';

class TabsScreen extends StatefulWidget {
  @override
  _TabsScreenState createState() => _TabsScreenState();
}

class _TabsScreenState extends State<TabsScreen> {
  final List<Map<String, Object>> _pages = [
    {'page': UpcomingEvets(), 'title': 'Eventet'},
    {'page': RandomTab(), 'title': 'Random'},
  ];
  int _selectedPageIndex = 0;

  void _selectPage(index) {
    if (index > _pages.length - 1) {
      index = _pages.length - 1;
    }
    setState(() {
      _selectedPageIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(_pages[_selectedPageIndex]['title']),
      ),
      body: _pages[_selectedPageIndex]['page'],
      bottomNavigationBar: BottomNavigationBar(
        onTap: _selectPage,
        backgroundColor: Colors.white,
        currentIndex: _selectedPageIndex,
        items: [
          if (Provider.of<Auth>(context, listen: false)
              .hasRole(Role.Businessman))
            BottomNavigationBarItem(
              icon: Icon(Icons.event_note),
              title: Text('Skeduli B'),
            ),
          BottomNavigationBarItem(
            icon: Icon(Icons.event),
            title: Text('Skeduli C'),
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.exit_to_app),
            title: Text('Another'),
          ),
        ],
      ),
    );
  }
}
