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
    .get("http://localhost:60438/api/SocialPost")
    .then(res => this.setState({ posts: res.data }));
  }

  componentDidMount() {
    this.getall()
  }

  addpost =  (postName, postDescription) =>{
    var pst={
      PostName:postName,
      PostDescription:postDescription
    }
   axios.post('http://localhost:60438/api/SocialPost',pst)
   .then(res => this.setState({ posts: 
    [...this.state.posts, res.data]}));
  };

  updatePost=(postId,postName,postDescription)=>{
		var pst={
			postName:postName,
			postDescription:postDescription
		  }
		 axios.put('http://localhost:60438/api/SocialPost/'+postId,pst)
		 .then(res => this.getall()
		 );
	}

  like =  (toggleLike, postId) =>{
    let option = "like";
    if(toggleLike){
      option="unlike"
    }
   axios.put('http://localhost:60438/api/SocialPost/LikesandHearts/'+option+'/'+postId,)
   .then(res => 
    this.getall())
  };

  heart =  (toggleHeart, postId) =>{
    let option = "heart";
    if(toggleHeart){
      option="disheart"
    }
    axios.put('http://localhost:60438/api/SocialPost/LikesandHearts/'+option+'/'+postId,)
    .then(res =>this.getall())
   };

  delPost = id => {
    axios.delete(`https://jsonplaceholder.typicode.com/posts/${id}`).then(res =>
      this.setState({
        posts: [...this.state.posts.filter(post => post.id !== id)]
      })
    );
  };

  render() {
    return (
      <div class="jumbotron jumbotron-fluid">
      <div class="container">
       <AddPost addpost={this.addpost}/>
        <Posts  posts = {this.state.posts}  likes={this.like} hearts={this.heart} updatePost={this.updatePost}/>
      </div>  
      </div>
    );
  }
}

export default App;