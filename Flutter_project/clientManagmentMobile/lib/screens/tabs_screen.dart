import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import './upcoming_business_events_screent.dart';
import './randomSecondTab.dart';
import '../providers/auth_provider.dart';

class _TabsIndexes {
  final Widget page;
  final String title;
  final int customerIndex;
  final int businessIndex;

  _TabsIndexes(this.page, this.title, this.customerIndex, this.businessIndex);
}

class TabsScreen extends StatefulWidget {
  @override
  _TabsScreenState createState() => _TabsScreenState();
}

class _TabsScreenState extends State<TabsScreen> {
  final List<_TabsIndexes> _pages = [
    _TabsIndexes(UpcomingBusinessEvents(), 'Events B', -1, 0),
    _TabsIndexes(RandomTab(), 'Random tab 1', 0, 1),
    _TabsIndexes(RandomTab(), 'Random tab 2', 1, 2),
  ];

  int _selectedPageIndex = 0;

  _TabsIndexes _getSelectedTabWidget() {
    _TabsIndexes curentTab;
    if (Provider.of<Auth>(context, listen: false).hasRole(Role.Businessman)) {
      curentTab = _pages.firstWhere(
          (element) => element.businessIndex == _selectedPageIndex,
          orElse: null);
    } else {
      curentTab = _pages.firstWhere(
          (element) => element.customerIndex == _selectedPageIndex,
          orElse: null);
    }

    if (curentTab == null) {
      curentTab = _pages.firstWhere((element) => element.customerIndex == 1);
    }

    return curentTab;
  }

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
        title: Text(_getSelectedTabWidget().title),
      ),
      body: _getSelectedTabWidget().page,
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
