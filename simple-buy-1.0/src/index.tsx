import React from 'react';
import ReactDOM from 'react-dom';
import {Provider} from 'react-redux'
import { applyMiddleware, createStore } from 'redux';
import thunk from 'redux-thunk';
import App from './App';
import rootReducer from './store/ducks/rootReducer';

ReactDOM.render(
    <Provider store={createStore(rootReducer, applyMiddleware(thunk))} >
      <App/>
    </Provider>,
  document.getElementById('root')
);

