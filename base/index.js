const express = require("express");
const mongoose = require("mongoose");
const bodyParser = require("body-parser");

mongoose.connect("mongodb://localhost:27017/leaderboard", {
    useNewUrlParser: true,
    useUnifiedTopology: true,
});

const playerScoreSchema = new mongoose.Schema({
    name: { type: String, required: true, unique: true },
    score: { type: Number, required: true },
});

const Leaderboard = mongoose.model("Leaderboard", playerScoreSchema);

const app = express();
app.use(bodyParser.json());



app.post("/api/leaderboard", async (req, res) => {
    const { name, score } = req.body;

    if (!name || !score) 
    {
        return res.status(400).json({ msg: "Please enter all fields" });
    }

    try 
    {
        let playerScore = await Leaderboard.findOne({ name });

        if (playerScore) 
            {
            playerScore.score = score;
            const updatedScore = await playerScore.save();
            return res.json(updatedScore);
        } 
        
        else 
        {
            const newScore = new Leaderboard({ name, score });
            const scoreSaved = await newScore.save();
            return res.json(scoreSaved);
        }

    } 
    
    catch (error) 
    {
        console.log(error);
        res.status(500).json({ msg: "Server Error" });
    }
});




app.get("/api/leaderboard", async (req, res) => {
    try {
        const scores = await Leaderboard.find().sort({ score: -1 });
        res.json(scores);
    } catch (error) {
        console.log(error);
        res.status(500).json({ msg: "Server Error" });
    }
});


const PORT = process.env.PORT || 3009;
app.listen(PORT, () => 
{
    console.log(`Server is running on port ${PORT}`);
});
