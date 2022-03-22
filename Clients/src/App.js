import './App.css';
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom'
import Posts from './Posts'
import Comments from './Comments'
import ViewComment from './ViewComment'

function App() {
  return (
    <div className='sr'>
        <Router>
              
                <div className="container">
                    <Switch> 
                          <Route path = "/" exact component = {Posts}></Route>
                          <Route path = "/Comments/:postId" component = {Comments}></Route>
                          <Route path = "/ViewComment/:commentId" component = {ViewComment}></Route>
                          
                    </Switch>
                </div>
             
        </Router>
    </div>
    
  );
}

export default App;