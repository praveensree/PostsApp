import React from 'react';
import Posts from './component/Posts' ;
import axios from 'axios';
import AddPost from './component/AddPost';

class App extends React.Component {

  state = {
    
    posts: []
  };
  getall=()=>{
    axios
    .get(`${process.env.REACT_APP_POST_URL}`)
    .then(res => this.setState({ posts: res.data }));
  }

  componentDidMount() {
    this.getall()
  }

  addpost =  (postName, postDescription) =>{
    if(postName!==''&& postDescription!=='')
    {
    const pst={
      PostName:postName,
      PostDescription:postDescription
    }
   axios.post(`${process.env.REACT_APP_POST_URL}`,pst)
   .then(res => this.setState({ posts: 
    [...this.state.posts, res.data]}));
  }
  else{
    alert("please type a value")
  }}
  
  

  updatePost=(postId,postName,postDescription)=>{
    if(postName!==''&& postDescription!=='')
    {
		const pst={
			postName:postName,
			postDescription:postDescription
		  }
		 axios.put(`${process.env.REACT_APP_POST_URL}/${postId}`,pst)
		 .then(res => this.getall()
		 );}
     else{
       alert("please type a value")
     }
	}

  like =  (toggleLike, postId) =>{
    let option = "like";
    if(toggleLike){
      option="unlike"
    }
   axios.put(`${process.env.REACT_APP_POST_URL}/LikesandHearts/${option}/${postId}`)
   .then(res => 
    this.getall())
  };

  heart =  (toggleHeart, postId) =>{
    let option = "heart";
    if(toggleHeart){
      option="disheart"
    }
    axios.put(`${process.env.REACT_APP_POST_URL}/LikesandHearts/${option}/${postId}`)
    .then(res =>this.getall())
   };

  render() {
    return (
      <div className="jumbotron jumbotron-fluid">
      <div className="container">
       <AddPost addpost={this.addpost}/>
        <Posts  posts = {this.state.posts}  likes={this.like} hearts={this.heart} updatePost={this.updatePost}/>
      </div>  
      </div>
    );
  }
}

export default App;