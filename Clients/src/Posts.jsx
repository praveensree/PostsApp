import React, { Component } from 'react'
import axios from 'axios'

export class Posts extends Component {
    constructor(props) {
        super(props);
        this.state = {
            postName: '',
            postDescription: '',
            commentDetail: {
                message:""
            },
            likes: 0,
            List: [],
            LikeButton: "👍",
            HeartButton: "Heart"
        };
        this.viewComments = this.viewComments.bind(this);
        this.AddPost = this.AddPost.bind(this);
    }
    resetForm = () => {
        this.setState({
            postName: '',
            postDescription: ''
        })
    }
    getPost = () => {
        axios.get("http://localhost:60438/api/SocialPost").then((response) => {

            this.setState({ List: response.data });

        }, []);
    }
    componentDidMount = () => {
        this.getPost();
    }
    AddPost = () => {
        var msg = {
            postName: this.state.postName,
            postDescription: this.state.postDescription,
        }
        axios.post('http://localhost:60438/api/SocialPost', msg
        )
            .then(res => {
                this.getPost();
            })
    }
    handleFieldChange = event => {
        const { value, message } = event.target;
    
        this.setState({
          ...this.state,
          commentDetail: {
            ...this.state.commentDetail,
            [message]: value
          }
        });
      };
    viewComments(postId) {
        this.props.history.push(`/Comments/${postId}`);
    }
    titleHandle = (e) => {
        this.setState({ postName: e.target.value });
    }
    descriptionHandle = (e) => {
        this.setState({ postDescription: e.target.value });
    }
    commentHandle = (e) => {
        this.setState({ commentDetail: e.target.value });
    }
    changeLike = () => {
        if (this.state.LikeButton === "👍")
            this.setState({ LikeButton: "👎" });
        else {
            this.setState({ LikeButton: "👍" });
        }
    }
    setLikes = (num) => {
        if (num === 0) {

        }
        else {

        }
    }
    setHearts = (num) => {
        if (num === 0) {

        }
        else {

        }
    }
    render() {
        return (
            <div>
                <input type="text" name="title" required className="search-box" onChange={this.titleHandle} placeholder="About" value={this.state.postName} />
                <br />
                <input type="text" name="description" required className="search-boxs" onChange={this.descriptionHandle} placeholder="ShareUs" value={this.state.postDescription} />
                <br />
                <span id='span'>
                    <button className="button-7" onClick={this.AddPost}>
                        Post
                    </button>
                    <button className="button-7" onClick={this.resetForm}>Cancel</button>
                </span>
                <h2 className="text-center">Posts</h2>
                {
                    this.state.List.map(list => (
                        <ul key={list.postId}>
                            <div className="back">
                                <li>
                                    <h4>{list.postName}</h4>
                                    <p>{list.postDescription}</p>
                                    <span>
                                        <button className="button-7" onClick={() => { this.setLike(list.postId) }}>{list.likes === 0 ? "👍" : "👎"}</button>Likes|: {list.likes}
                                    </span>
                                    <span>
                                        <button className="button-7" onClick={this.setHearts(list.postId)}>{list.hearts === 0 ? "❤️" : "💔"}</button>Hearts|: {list.hearts}
                                    </span>
                                    <span>
                                    <button className="button-7" onClick={() => this.viewComments(list.postId)}>View comments</button>
                                    </span>
                                    <div>
                                    <span>
                                    <input type="text" name="comment" required className="search-boxss"  onChange={this.handleFieldChange } value={this.state.commentDetail.message} placeholder="write your comments" />
                                        <button className="button-7" onClick={() => this.viewComments(list.postId)}>+ Comment</button>
                                    </span>
                                    </div>
                                </li>
                            </div>
                        </ul>
                    ))
                }
            </div>
        )
    }
}

export default Posts